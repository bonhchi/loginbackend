using Service.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Service.Auth
{
    class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtManager _jwtManager;

        public AuthService(IUserService userService, IJwtManager jwtManager)
        {
            _userService = userService;
            _jwtManager = jwtManager;
        }

        public string CheckLogin(string email, string password)
        {
            var user = _userService.GetByEmail(email);
            if(user == null)
            {
                throw new Exception("User is not found");
            }
            if(!string.Equals(user.Password, password, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception("Invalid password");
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} ${user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = _jwtManager.GenerateToken(claims, DateTime.UtcNow);
            return token;
        }
    }
}
