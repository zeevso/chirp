using ChirpServer.DTO;
using ChirpServer.Helpers;
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
    public class UsersController : Controller
    {
        private readonly IDataAccess _data;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;

        public UsersController(IDataAccess data, IConfiguration config, IJwtService jwtService)
        {
            _data = data;
            _config = config;
            _jwtService = jwtService;
        }

        [HttpPost(template: "follow")]
        public async Task<IActionResult> Follow(FollowerDTO dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);

                string sql = "select name from user where id = @id";
                var follower = await _data.LoadDataObject<string, dynamic>(sql, new { id = userId }, _config.GetConnectionString("default"));

                sql = "insert into followers (follower, followed) values (@follower, @followed)";
                await _data.SaveData(sql, new { follower = follower, followed = dto.FollowedName }, _config.GetConnectionString("default"));

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }  
        }

        [HttpPost(template: "unfollow")]
        public async Task<IActionResult> UnFollow(FollowerDTO dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);

                string sql = "select name from user where id = @id";
                var follower = await _data.LoadDataObject<string, dynamic>(sql, new { id = userId }, _config.GetConnectionString("default"));

                sql = "delete from followers where (follower = @follower and followed = @followed)";
                await _data.SaveData(sql, new { follower = follower, followed = dto.FollowedName }, _config.GetConnectionString("default"));

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}
