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
using Microsoft.AspNetCore.Authorization;

namespace LunarSports.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> userManager { get; }
        public SignInManager<IdentityUser> signInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }
        
        [AllowAnonymous]

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
            var result = await userManager.CreateAsync(user, formInput.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Default");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel formInput)
        {
            Boolean isValid = ModelState.IsValid;

            if (!isValid)
            {
                return View(formInput);
            }

            var result = await signInManager.PasswordSignInAsync(formInput.UserName, formInput.Password, formInput.RememberMe, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default");

            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(formInput);

        }




        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");

        }



    }
}
