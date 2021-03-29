using Common.Http;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject.Controllers
{
    
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("api/user/{email}")]
        [Authorize]
        public IActionResult Get([FromQuery] SearchUserDto searchModel)
        {
            var users = _userService.GetList(searchModel);
            return Ok(users);
        }

        [Authorize]
        [HttpGet("api/user/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return CommonResponse(404, "User is not found");
            }
            return CommonResponse(0, user);
        }

        //[HttpPost("login")]
        //[EnableCors("LoginCors")]
        //public IActionResult Login([FromBody] LoginDto model)
        //{
        //    bool result = _userService.Login(model);
        //    return Ok(result);
        //}
    }
}
