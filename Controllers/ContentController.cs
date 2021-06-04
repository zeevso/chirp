using ChirpServer.DTO;
using ChirpServer.Helpers;
using ChirpServer.Models;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

                var message = new MessageModel
                {
                    userName = messanger,
                    message = dto.messageText
                };

                sql = "insert into messages (username, message) values (@username, @message)";
                await _data.SaveData(sql, new { username = message.userName, message = message.message }, _config.GetConnectionString("default"));

                return Ok(message);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}
