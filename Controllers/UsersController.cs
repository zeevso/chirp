using ChirpServer.DTO;
using ChirpServer.Helpers;
using ChirpServer.Models;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly ILogger<UsersController> _logger;

        public UsersController(IDataAccess data, IConfiguration config, IJwtService jwtService, ILogger<UsersController> logger)
        {
            _data = data;
            _config = config;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost(template: "follow")]
        public async Task<IActionResult> Follow(FollowerDTO dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                int userId = _jwtService.WrapJWTSecurityToken(jwt);

                var follower = await _data.LoadDataObject<string, dynamic>("select name from user where id = @id",
                    new { id = userId }, _config.GetConnectionString("default"));            
                
                if (follower == dto.FollowedName)
                {
                    _logger.LogWarning("Curios, user wants to follow himself. Check!");
                    return BadRequest(error: new { message = "User cannot follow himself" });
                }

                string sql = "insert into followers (follower, followed) values (@follower, @followed)";
                await _data.SaveData(sql, new { follower = follower, followed = dto.FollowedName }, _config.GetConnectionString("default"));

                _logger.LogInformation("Following OK!");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The unathorised user tried to enter! Code: {Code}", " 401");
                return Unauthorized();
            }  
        }

        [HttpPost(template: "unfollow")]
        public async Task<IActionResult> UnFollow(FollowerDTO dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                int userId = _jwtService.WrapJWTSecurityToken(jwt);

                var follower = await _data.LoadDataObject<string, dynamic>("select name from user where id = @id",
                    new { id = userId }, _config.GetConnectionString("default"));

                var sql = "delete from followers where (follower = @follower and followed = @followed)";
                await _data.SaveData(sql, new { follower = follower, followed = dto.FollowedName }, _config.GetConnectionString("default"));

                _logger.LogInformation("Unfollowing OK!");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The unathorised user tried to enter! Code: {Code}", " 401");
                return Unauthorized();
            }
        }

        [HttpGet(template: "users")]
        public async Task<IActionResult> GetUsersExceptAuthenticated()
        {
            List<PartUser> users;

            try
            {
                var jwt = Request.Cookies["jwt"];
                int userId = _jwtService.WrapJWTSecurityToken(jwt);

                // Fetch all users except one that maked a request
                var sql = "select id, name from user where (id != @id)";
                users = await _data.LoadData<PartUser, dynamic>(sql, new { id = userId }, _config.GetConnectionString("default"));

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The unathorised user tried to enter! Code: {Code}", " 401");
                return Unauthorized();
            }
        }

        // Get the list of all followed by the specific user
        [HttpGet(template: "followed")]
        public async Task<IActionResult> GetFollowed()
        {
            List<FollowedModel> followed;

            try
            {
                var jwt = Request.Cookies["jwt"];
                int userId = _jwtService.WrapJWTSecurityToken(jwt);

                var follower = await _data.LoadDataObject<string, dynamic>("select name from user where id = @id",
                    new { id = userId }, _config.GetConnectionString("default"));

                var sql = "select followed from followers where (follower = @follower)";
                followed = await _data.LoadData<FollowedModel, dynamic>(sql, new { follower = @follower}, _config.GetConnectionString("default"));               

                return Ok(followed);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The unathorised user tried to enter! Code: {Code}", " 401");
                return Unauthorized();
            }
        }
    }
}
