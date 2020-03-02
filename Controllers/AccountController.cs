using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;
using LunarSports.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LunarSports.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel formInput)
        {
            Boolean isValid = ModelState.IsValid;
            ViewData["test"] = isValid.ToString();
            if (!isValid)
            {
                return View(formInput); 
            }
            var user = new IdentityUser { UserName = formInput.UserName, Email = formInput.Email };
            var result = await UserManager.CreateAsync(user, formInput.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("index", "default");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(LoginUserModel formInput)
        {
            Boolean isValid = ModelState.IsValid;
            ViewData["test"] = isValid.ToString();
            if (!isValid)
            {
                Console.Write("The provided model is not valid");
            }
            Console.Write("The provided model is valid");

            return View();

        }



    }
}
