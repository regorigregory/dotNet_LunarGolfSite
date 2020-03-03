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
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            var user = new ApplicationUser { UserName = formInput.UserName, Email = formInput.Email, DOB = formInput.DOB };

            var result = await userManager.CreateAsync(user, formInput.Password);
            var result2 = await userManager.AddToRoleAsync(user, formInput.SpecRole);
            if (result.Succeeded && result2.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Default");
            }

            foreach (var error in result.Errors)
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



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");

        }


        //[Authorize]
        //[HttpPost]
        public async Task<IActionResult> EditUserDetails()
        {
            if (User != null)
            {
                ApplicationUser ux = await userManager.GetUserAsync(User);
                EditUserModel em = new EditUserModel(ux);
                return View(em);
            }
            string successURL = string.Format("/Default/Feedback?message={0}", "You have to log in in order to edit your user details.");

            return Redirect(successURL);

        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateUserDetails(EditUserModel formInput)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser ux = await userManager.GetUserAsync(User);
                bool result = await userManager.CheckPasswordAsync(ux, formInput.OldPassword);

                if (result)
                {
                    ux.FirstName = formInput.FirstName;
                    ux.LastName = formInput.LastName;
                    ux.Email = formInput.Email;
                    ux.BIO = formInput.BIO;
                    ux.ProfilePictureURL = formInput.ProfilePictureURL;
                    ux.Gender = formInput.Gender;
                    ux.DOB =formInput.DOB;
                    ux.ProfilePictureURL = formInput.ProfilePictureURL;

                    string successURL = string.Format("/Default/Feedback?message={0}", "The account details have been updated successfully.");

                    IdentityResult tempResult = await userManager.UpdateAsync(ux);

                    if ((formInput.Password == null & tempResult.Succeeded))
                    {
                        return Redirect(successURL);

                    }
                    else if (formInput.Password != null & tempResult.Succeeded)
                    {
                        IdentityResult tempResult2 = await userManager.ChangePasswordAsync(ux, formInput.OldPassword, formInput.Password);
                        if (tempResult2.Succeeded)
                        {
                            return Redirect(successURL);
                        }
                        else
                        {
                            ModelState.AddModelError("", "The provided current password is invalid.");
                        }

                    }


                }

            }
            return View(User);

        }
    }
}
