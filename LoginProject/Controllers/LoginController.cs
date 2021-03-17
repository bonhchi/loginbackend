using LoginProject.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [EnableCors("CorsPolicy")]
    public class LoginController : ControllerBase
    {
        private readonly UserData _userData;

        public LoginController(UserData userData)
        {
            _userData = userData;
        }
        //[HttpGet]
        //public string LoginString()
        //{
        //    return "abc";
        //}
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid client request");
            bool existUser = _userData.Users.Exists(p => p.Username == user.Username && p.Password == user.Password);
            if (existUser)
                return Ok(new { Token = "Login done" });
            return Unauthorized();
        }
    }
}
