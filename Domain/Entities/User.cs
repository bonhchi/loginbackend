using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public int Status { get; set; }

        public static List<User> GetData()
        {
            var users = new List<User> {
            new User{
                Id = new Guid( "72de3e48-4c34-463f-832e-3422b8947b46"),
                Email =  "test@gmail.com",
                FirstName = "Buckner",
                LastName = "Martinez",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2014-06-26T12:14:17 -07:00"),
                Modified =  DateTimeOffset.Parse("2014-01-10T11:38:34 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "775a0022-a918-4e6a-a46c-d4ffb8d6f27e"),
                Email =  "bucknermartinez@lunchpod.com",
                FirstName = "Francine",
                LastName = "Leon",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2014-10-06T10:49:27 -07:00"),
                Modified = DateTimeOffset.Parse("2014-01-23T11:11:56 -07:00"),
                Status =  1
            }};
                
                

            return users;
        }
    }
}
