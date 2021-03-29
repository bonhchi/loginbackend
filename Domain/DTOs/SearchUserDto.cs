using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class SearchUserDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
        public int Take
        {
            get
            {
                return PageIndex * PageSize;
            }
        }
    }
}
