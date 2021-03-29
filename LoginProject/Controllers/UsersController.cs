using Domain.DTOs;
using LoginProject.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserDto searchModel)
        {
            var users = _userService.GetList(searchModel);
            return Ok(users);
        }

        [HttpPost("login")]
        [EnableCors("LoginCors")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            bool result = _userService.Login(model);
            return Ok(result);
        }
    }
}
