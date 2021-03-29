using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Users
{
    public interface IUserService
    {
        public bool Login(LoginDto model);
        public SearchPagingDto GetList(SearchUserDto searchModel);

        IEnumerable<User> GetAll();

        User GetByEmail(string email);
    }
}
