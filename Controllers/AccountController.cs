﻿using System;
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
   // [Area("Public")]
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public RoleManager<IdentityRole> roleManager { get; }

        private LunarSportsDBContext _context;
        public AccountController(LunarSportsDBContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
           
        }

        public async Task<int> initDBRoles()
        {
            //error checking is left to do
            var exists = await roleManager.RoleExistsAsync("Administrator");
            IdentityRole newRole = new IdentityRole { Name = "Administrator" };

            if (!exists)
            {
                IdentityResult result = await roleManager.CreateAsync(newRole);

            }
            exists = await roleManager.RoleExistsAsync("Customer");
            newRole = new IdentityRole { Name = "Customer" };
            if (!exists)
            {
                IdentityResult result = await roleManager.CreateAsync(newRole);

            }
            return 1;
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
            await initDBRoles();



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
                EditUserModel em = new EditUserModel(this._context);
                em.SetApplicationUserDetails(ux);
                em.GetAdditionalUserDetails();
                return View(em);
            }

            string successURL = string.Format("/Default/Feedback?message={0}", "You have to log in in order to edit your user details.");

            return Redirect(successURL);

        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateUserDetails(EditUserModel formInput)
        {

            if (User == null)
            {
                string successURL = string.Format("/Default/Feedback?message={0}", "You have to log in in order to edit your user details.");

                return Redirect(successURL);
            }

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

                    if (tempResult.Succeeded)
                    {
                        UserAddress ha = formInput.HomeAddress;
                        formInput.HomeContact.User = ux.Id;
                        formInput.HomeContact.IsPrimary = true;
                        formInput.HomeContact.IsNextOfKin = false;

                        formInput.WorkContact.User = ux.Id;
                        formInput.WorkContact.IsPrimary = false;
                        formInput.WorkContact.IsNextOfKin = false;


                        formInput.NextOfKin.UserID = ux.Id;

                        formInput.NOKAddress.User = ux.Id;
                        formInput.NOKAddress.IsNextOfKin = true;

                        formInput.NOKContact.User = ux.Id;
                        formInput.NOKContact.IsNextOfKin = true;

                        EditUserModel currentlyStored = new EditUserModel(this._context);
                        currentlyStored.SetApplicationUserDetails(ux);
                        currentlyStored.GetAdditionalUserDetails();


                        if(currentlyStored.HomeAddress == null) this._context.UserAddresseses.Add(formInput.HomeAddress); else currentlyStored.HomeAddress.UpdateMe(formInput.HomeAddress);

                        if (currentlyStored.WorkAddress == null) this._context.UserAddresseses.Add(formInput.WorkAddress); else currentlyStored.WorkAddress.UpdateMe(formInput.WorkAddress);

                        if (currentlyStored.HomeContact == null) this._context.UserContactDetails.Add(formInput.HomeContact); else currentlyStored.HomeContact.UpdateMe(formInput.HomeContact);

                        if (currentlyStored.WorkContact == null) this._context.UserContactDetails.Add(formInput.WorkContact); else currentlyStored.WorkContact.UpdateMe(formInput.WorkContact);

                        if (currentlyStored.NextOfKin == null) this._context.NextOfKins.Add(formInput.NextOfKin); else currentlyStored.NextOfKin.UpdateMe(formInput.NextOfKin);

                        if (currentlyStored.NOKAddress == null) this._context.UserAddresseses.Add(formInput.NOKAddress); else currentlyStored.NOKAddress.UpdateMe(formInput.NOKAddress);

                        if (currentlyStored.NOKContact == null) this._context.UserContactDetails.Add(formInput.NOKContact); else currentlyStored.NOKContact.UpdateMe(formInput.NOKContact);
                    }

                    if ((formInput.Password == null & tempResult.Succeeded))
                    {
                        this._context.SaveChanges();
                        return Redirect(successURL);
                    }
                    else if (formInput.Password != null & tempResult.Succeeded)
                    {
                        IdentityResult tempResult2 = await userManager.ChangePasswordAsync(ux, formInput.OldPassword, formInput.Password);
                        if (tempResult2.Succeeded)
                        {
                            this._context.SaveChanges();
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
