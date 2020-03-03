using LunarSports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        public RoleManager<IdentityRole> RoleManager { get; }

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
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
        public IActionResult CreatePage()
        {
            throw new NotImplementedException();
        }
        public IActionResult EditPage()
        {
            throw new NotImplementedException();
        }
        public IActionResult DeletePage()
        {
            throw new NotImplementedException();
        }
        public IActionResult ListPages()
        {
            throw new NotImplementedException();
        }

        public IActionResult CreateEvent()
        {
            throw new NotImplementedException();
        }
        public IActionResult EditEvent()
        {
            throw new NotImplementedException();
        }
        public IActionResult DeleteEvent()
        {
            throw new NotImplementedException();
        }
        public IActionResult ListEvents()
        {
            throw new NotImplementedException();
        }
    }
}
