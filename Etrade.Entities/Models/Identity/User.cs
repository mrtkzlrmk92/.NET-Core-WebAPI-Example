using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entities.Models.Identity
{
    public class User:IdentityUser<int>
    {
        public User():base()
        {
            CreatedDate= DateTime.Now;
        }
        public User(string username):base(username)
        {
            CreatedDate = DateTime.Now;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
