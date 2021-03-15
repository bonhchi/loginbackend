using LoginProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly UserData _userData;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserData userData, SignInManager<User> signInManager)
        {
            _userData = userData;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            List<User> user = _userData.Users; 
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var result = await _signInManager.PasswordSignInAsync(user, user.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction();
            }
            else
            {
                ModelState.AddModelError("", "Username hoặc mật khẩu sai");
                return View();
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
