using ChirpServer.DTO;
using ChirpServer.Helpers;
using ChirpServer.Models;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChirpServer.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class ContentController : Controller
    {
        private readonly IDataAccess _data;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;
        public ContentController(IDataAccess data, IConfiguration config, IJwtService jwtService)
        {
            _data = data;
            _config = config;
            _jwtService = jwtService;
        }

        [HttpPost(template: "message")]
        public async Task<IActionResult> PostMessage(PostMessageDTO dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);

                string sql = "select name from user where id = @id";
                var messanger = await _data.LoadDataObject<string, dynamic>(sql, new { id = userId }, _config.GetConnectionString("default"));
                if (dto.messageText.Length > 140)
                {
                    return Ok(new { message = "Message exceeds max length" });
                }

                sql = "insert into messages (username, message) values (@username, @message)";
                await _data.SaveData(sql, new { username = messanger, message = dto.messageText }, _config.GetConnectionString("default"));

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpGet(template: "fullfeed")]
        public async Task<IActionResult> GetFeed(string username)
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);
            int userId = int.Parse(token.Issuer);

            List<MessageModel> feed;
            string searchPattern = "'" + username + "%'";
            var sql = "select * from messages where username like " + searchPattern + " order by datecreated desc";
            feed = await _data.LoadData<MessageModel, dynamic>(sql, new { }, _config.GetConnectionString("default"));
            return Ok(feed);
        }

        [HttpGet(template: "partfeed")]
        public async Task<IActionResult> GetMyFeed()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var ws = new WebSocketConnection(await HttpContext.WebSockets.AcceptWebSocketAsync());

                List<MessageModel> feed;

                try
                {
                    while (true)
                    {
                        var username = await ws.ReceiveString();
                        var searchPattern = "'" + username + "%'";
                        var query = @"select f.followed, m.message
                        from followers f
                        join messages m on f.followed = m.username
                        where f.follower like " + searchPattern + " order by datecreated desc";
                        feed = await _data.LoadData<MessageModel, dynamic>(query, new { }, _config.GetConnectionString("default"));
                        await ws.SendObject(feed);
                    }
                }
                catch (WebSocketException) {}
                finally
                {
                    await ws.Close();
                }

                return new EmptyResult();
            }
            else
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}
