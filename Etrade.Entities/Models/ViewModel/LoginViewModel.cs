using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entities.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="Kullanıcı Adı veya Email")]
        public string UsernameOrEmail { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool  RememberMe { get; set; }
    }
}
