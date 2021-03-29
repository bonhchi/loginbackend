using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public int Type { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SearchPagingDto
    {
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages
        {
            get
            {
                if (PageSize <= 0)
                {
                    PageSize = 1;
                }
                return (int)Math.Round((decimal)TotalItems / PageSize, MidpointRounding.AwayFromZero);
            }
        }

        public List<UserDto> Data { get; set; }
    }
}
