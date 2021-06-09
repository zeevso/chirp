using ChirpServer.DTO;
using ChirpServer.Helpers;
using ChirpServer.Models;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
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
        private readonly ILogger<ContentController> _logger;
        public ContentController(IDataAccess data, IConfiguration config, IJwtService jwtService, ILogger<ContentController> logger)
        {
            _data = data;
            _config = config;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost(template: "message")]
        public async Task<IActionResult> PostMessage(PostMessageDTO dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                int userId = _jwtService.WrapJWTSecurityToken(jwt);

                string sql = "select name from user where id = @id";
                var messenger = await _data.LoadDataObject<string, dynamic>(sql, new { id = userId }, _config.GetConnectionString("default"));

                if (dto.messageText.Length > 140)
                {
                    _logger.LogWarning("Message can't be that long");
                    return Ok(new { message = "Message exceeds max length" });
                }

                sql = "insert into messages (username, message) values (@username, @message)";
                await _data.SaveData(sql, new { username = messenger, message = dto.messageText }, _config.GetConnectionString("default"));

                _logger.LogInformation("Post Message Success!");
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The unathorised user tried to enter! Code: {Code}", " 401");
                return Unauthorized();
            }
        }

        // Filter feed using Web Sockets to achieve speed
        [HttpGet(template: "wsfullfeed")]
        public async Task<IActionResult> GetWSFullFeed()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var jwt = Request.Cookies["jwt"];
                _jwtService.WrapJWTSecurityToken(jwt);

                var ws = new WebSocketConnection(await HttpContext.WebSockets.AcceptWebSocketAsync());

                List<MessageModel> feed;

                try
                {
                    while (true)
                    {
                        var username = await ws.ReceiveString();
                        var searchPattern = "'" + username + "%'";
                        var sql = @"select * from messages 
                                    where username like " + searchPattern +
                                    " order by datecreated desc";
                        feed = await _data.LoadData<MessageModel, dynamic>(sql, new { }, _config.GetConnectionString("default"));
                        await ws.SendObject(feed);
                    }
                }
                catch (WebSocketException) 
                {
                    _logger.LogWarning("Feed could not be loaded! Communication Error: {Code}", " 400");
                }
                finally
                {
                    await ws.Close();
                }

                return new EmptyResult();
            }
            else
            {
                _logger.LogWarning("Feed could not be loaded! Communication Error: {Code}", " 400");
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        // Filter feed using Web Sockets to achieve speed
        [HttpGet(template: "wsfollowedfeed")]
        public async Task<IActionResult> WSGetFollowedFeed()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var jwt = Request.Cookies["jwt"];
                int userId = _jwtService.WrapJWTSecurityToken(jwt);

                var username = await _data.LoadDataObject<string, dynamic>("select name from user where id = @id",
                    new { id = userId }, _config.GetConnectionString("default"));

                var ws = new WebSocketConnection(await HttpContext.WebSockets.AcceptWebSocketAsync());

                List<MessageModel> feed;

                try
                {
                    while (true)
                    {
                        var filtername = await ws.ReceiveString();
                        var searchPattern = "'" + filtername + "%'";
                        var sql = @"select f.followed as username, m.message, m.datecreated
                                from followers f
                                left join messages m on m.username = f.followed
                                where f.follower = @username and username like" + searchPattern + @" and m.message is not null
                                order by datecreated desc";
                        feed = await _data.LoadData<MessageModel, dynamic>(sql,
                            new { username = username }, _config.GetConnectionString("default"));
                        await ws.SendObject(feed);
                    }
                }
                catch (WebSocketException) 
                {
                    _logger.LogWarning("Filtered feed could not be loaded! Communication Error: {Code}", " 400");
                }
                finally
                {
                    await ws.Close();
                }

                return new EmptyResult();
            }
            else
            {
                _logger.LogWarning("Filtered feed could not be loaded! Communication Error: {Code}", " 400");
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}
