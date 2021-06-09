using ChirpServer.DTO;
using ChirpServer.Helpers;
using ChirpServer.Models;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ChirpServer.Controllers
{
    [Route(template:"api")]
    [ApiController]
    public class AuthController: Controller
    {
        private readonly IDataAccess _data;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IDataAccess data, IConfiguration config, IJwtService jwtService, ILogger<AuthController> logger)
        {
            _data = data;
            _config = config;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost(template:"register")]
        public IActionResult SignUp(SignUpDto dto)
        {
            var user = new User
            {
                Name = dto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            
            string sql = "insert into user (name, password) values (@name, @password);";           

            return Created(uri:"success",
                value: _data.SaveData(sql, new { name = user.Name, password = user.Password }, _config.GetConnectionString("default")));
        }

        [HttpPost(template: "login")]
        public async Task<IActionResult> SignIn(SignInDto dto)
        {
            List<User> users;

            string sql = "select * from user where name = @name";
            users = await _data.LoadData<User, dynamic>(sql, new { name = dto.UserName }, _config.GetConnectionString("default"));
            if (users?.Any() == false)
            {
                _logger.LogWarning("Invalid Credentials! Code: {Code}", " 401");
                return BadRequest(error: new { message = "Invalid Credentials" });                
            }

            if (!BCrypt.Net.BCrypt.Verify(text: dto.Password, hash: users[0].Password))
            {
                _logger.LogWarning("Invalid Credentials! Code: {Code}", " 401");
                return BadRequest(error: new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.generateToken(users[0].Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new { message = "success" });
        }

        [HttpGet (template:"user")]
        public async Task <IActionResult> authUser()
        {
            User user;
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);

                string sql = "select * from user where id = @id";
                user = await _data.LoadDataObject<User, dynamic>(sql, new { id = userId }, _config.GetConnectionString("default"));

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "The unathorised user tried to enter! Code: {Code}", " 401");
                return Unauthorized();
            }
        }

        [HttpPost(template:"logout")]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("jwt");

            _logger.LogWarning("User logged out");
            return Ok(new
            {
                message = "success"
            });
        }


    }
}
