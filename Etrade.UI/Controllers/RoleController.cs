using Etrade.Entities.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> roleManager;

        public RoleController(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles.Where(i=>i.Name != "admin").ToList());
        }
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Role model)
        {
            var role = await roleManager.FindByNameAsync(model.Name);
            if(role == null)
            {
               var result = await roleManager.CreateAsync(model);
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Role model)
        {
            var role = await roleManager.FindByIdAsync(model.Id.ToString());
            role.Name = model.Name;
            var result = await roleManager.UpdateAsync(role);
            if(result.Succeeded)
                return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            var result = await roleManager.DeleteAsync(role);

            if(result.Succeeded)
                return RedirectToAction("Index");

            return NotFound("Role bulunamadı");
        }
    }
}
