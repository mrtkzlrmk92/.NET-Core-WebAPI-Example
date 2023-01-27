using Etrade.Entities.Models.Identity;
using Etrade.Entities.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Register()
        {
            if(User.Identity.Name != null)
                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new User()
            {
                Name= model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user,model.Password);
            await userManager.AddToRoleAsync(user, "user");
            if (result.Succeeded)
                RedirectToAction("Login");

            return View(model);
        }

        public async Task<IActionResult> Login()
        {
            if (User.Identity.Name != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = new User();
           if(model.UsernameOrEmail.IndexOf("@") >= 0)
            {
                user = await userManager.FindByEmailAsync(model.UsernameOrEmail);
            }
           else
            {
                user = await userManager.FindByNameAsync(model.UsernameOrEmail);
            }

           if(user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
           return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
