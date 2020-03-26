using System;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using LunarSports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LunarSports.Areas.Admin.Controllers
{ 

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class CustomerController : Controller
    {

        public UserManager<ApplicationUser> userManager { get; }

        public CustomerController(UserManager<ApplicationUser> userManagerr)
        {
            this.userManager = userManagerr;
        }
        // GET: Customer
        public ActionResult Index()
        {
            IQueryable<ApplicationUser> currentUsers = userManager.Users;
            return View(currentUsers);
        }


        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            // var user = userManager.GetUserAsync(id);
            var user = userManager.FindByIdAsync(id);
            return View(user);
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterUserModel formInput)
        {
            Boolean isValid = ModelState.IsValid;

            if (!isValid)
            {
                return View(formInput);
            }
            var user = new ApplicationUser { UserName = formInput.UserName, Email = formInput.Email, DOB = formInput.DOB };

            var result = await userManager.CreateAsync(user, formInput.Password);
            var result2 = await userManager.AddToRoleAsync(user, formInput.SpecRole);
            if (result.Succeeded && result2.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

       

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            var user = userManager.FindByIdAsync(id);
            return View(user);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var user = userManager.FindByIdAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}