using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;
using Microsoft.AspNetCore.Identity;
using LunarSports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace LunarSports.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ApplicationRolesController : Controller
    {
        public RoleManager<IdentityRole> RoleManager { get; }
        public   ApplicationRolesController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        public IActionResult Index()
        {

            IEnumerable<IdentityRole> currentRoles = RoleManager.Roles;
            return View(currentRoles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleModel formInput)
        {
            if (ModelState.IsValid)
            {
                IdentityRole newRole = new IdentityRole { Name = formInput.RoleName };
                IdentityResult result = await RoleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ApplicationRoles");
                }
                foreach (IdentityError e in result.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            //view gets rerendered with Validation error.
            return View(formInput);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            IdentityRole ir = await RoleManager.FindByNameAsync(id);

            return View(ir);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id, IFormCollection formdata)
        {
            IdentityRole ir = await RoleManager.FindByNameAsync(id);
            var result = await RoleManager.DeleteAsync(ir);
            if (!result.Succeeded)
            {
                string successURL = string.Format("/Default/Feedback?message={0}", "The deletion of the role was not successful.");

                return Redirect(successURL);
            }
            return RedirectToAction("Index", "ApplicationRoles");
        }


    }
}

