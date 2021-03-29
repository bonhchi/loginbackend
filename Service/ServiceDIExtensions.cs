using Microsoft.Extensions.DependencyInjection;
using Service.Auth;
using Service.Products;
using Service.Repository;
using Service.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public static class ServiceDIExtensions
    {
        public static void UserShopService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
