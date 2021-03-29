using Common.Http;
using Common;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("api/auth/get")]
        public IActionResult GetAny()
        {
            return new JsonResult(new { x = 12, y = "Test" });
        }
        [Route("api/auth/login")]
        public IActionResult Login([FromBody]LoginDto model)
        {
            if(!ModelState.IsValid || model == null || string.IsNullOrWhiteSpace(model.Email))
            {
                return CommonResponse(1, Constant.InvalidAuthInfoMsg);
            }
            try
            {
                var token = _authService.CheckLogin(model.Email, model.Password);
                return CommonResponse(0, token);
            }
            catch
            {
                return CommonResponse(1, Constant.InvalidAuthInfoMsg);
            }
        }
    }
}
