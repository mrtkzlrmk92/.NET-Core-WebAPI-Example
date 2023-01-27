using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entities.Models.Identity
{
    public class Role:IdentityRole<int>
    {
        public Role():base()
        {

        }
        public Role(string rolename):base(rolename) 
        {

        }
    }
}
