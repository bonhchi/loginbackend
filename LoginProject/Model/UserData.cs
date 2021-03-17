using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Model
{
    public class UserData
    {
        public List<User> Users { get; set; }
        public static UserData InitData()
        {
            List<User> users = new List<User>();
            users.AddRange(new List<User>
            {
                new User()
                {
                    Username = "abc",
                    Password = "12345"
                },
                new User()
                {
                    Username = "def",
                    Password = "12356"
                }
            });
            return new UserData()
            {
                Users = users
            };
        }
    }
}
