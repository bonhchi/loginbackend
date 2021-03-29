using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Users
{
    public class UserService : IUserService
    {
        private readonly List<User> users;
        private IMapper _mapper;

        public UserService(IMapper mapper)
        {
            users = User.GetData();
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetByEmail(string email)
        {
            return users.FirstOrDefault(item => string.Equals(item.Email, email, StringComparison.InvariantCultureIgnoreCase));
        }

        public SearchPagingDto GetList(SearchUserDto searchModel)
        {
            if (searchModel != null)
            {
                var result = _mapper.Map<SearchUserDto, SearchPagingDto>(searchModel);
                var data = users.Take(searchModel.Take).Skip(searchModel.PageSize).ToList();
                result.Data = _mapper.Map<List<User>, List<UserDto>>(data);
                result.TotalItems = users.Count();
                return result;
            }
            return new SearchPagingDto();
        }

        public bool Login(LoginDto model)
        {
            var result = users.Any(t => t.Email == model.Email && t.Password == model.Password);
            return result;
        }
    }
}
