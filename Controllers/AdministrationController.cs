using LunarSports.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Controllers
{
    public class AdministrationController : Controller
    {
        public RoleManager<IdentityRole> RoleManager { get; }

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel formInput)
        {
            if (ModelState.IsValid)
            {
                IdentityRole newRole = new IdentityRole { Name = formInput.RoleName };
               IdentityResult result = await RoleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }

                foreach(IdentityError e in result.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            //view gets rerendered with Validation error.
            return View(formInput);
        }
    }
}
