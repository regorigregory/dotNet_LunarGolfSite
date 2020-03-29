using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using LunarSports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace LunarSports.Areas.Admin.Controllers
{ 

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {

        private LunarSportsDBContext _context;
        public UserController(UserManager<ApplicationUser> userManagerr, LunarSportsDBContext ctx)
        {
            this.userManager = userManagerr;
            this._context = ctx;
        }


        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        // GET: Customer
        public ActionResult Index()
        {
           var currentUsers = userManager.Users.Select(au=> new ListUserViewModel(au)).ToList();
            return View(currentUsers);
        }


        // GET: Customer/Details/5
       
    

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Roles = this.roleManager.Roles.Select(r => r.Name).ToList<string>();

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
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser ux = await userManager.FindByIdAsync(id);
            if (ux != null)
            {
                ViewBag.Roles = this.roleManager.Roles.Select(r => r.Name).ToList<string>();
                EditUserModel eum = new EditUserModel(ux);
                return View(eum);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUserDetails(AdminEditUserModel formInput)
        {

            if (ModelState.IsValid)
            {

                ApplicationUser ux = await userManager.FindByIdAsync(formInput.Id);

                if (ux != null)
                {
                    ux.FirstName = formInput.FirstName;
                    ux.LastName = formInput.LastName;
                    ux.Email = formInput.Email;
                    ux.BIO = formInput.BIO;
                    ux.ProfilePictureURL = formInput.ProfilePictureURL;
                    ux.Gender = formInput.Gender;
                    ux.DOB = formInput.DOB;

                    string successURL = string.Format("/Default/Feedback?message={0}", "The account details have been updated successfully.");

                    IdentityResult tempResult = await userManager.UpdateAsync(ux);

                    //this should be populated from the database ->done :) Now you only have to update it in the views: 
                    //Register user, and admin create and update user views
                    var userRoles = this.roleManager.Roles.Select(r=>r.Name).ToList<string>();
                    foreach( string role in userRoles)
                    {
                        if(await userManager.IsInRoleAsync(ux, role))
                        {
                            await userManager.RemoveFromRoleAsync(ux, role);
                        }
                    }

                    var result2 = await userManager.AddToRoleAsync(ux, formInput.SpecRole);

                    if (tempResult.Succeeded)
                    {
                        formInput.HomeContact.User = ux.Id;
                        formInput.HomeContact.IsPrimary = true;
                        formInput.HomeContact.IsNextOfKin = false;

                        formInput.WorkContact.User = ux.Id;
                        formInput.WorkContact.IsPrimary = false;
                        formInput.WorkContact.IsNextOfKin = false;


                        formInput.HomeAddress.User = ux.Id;
                        formInput.HomeAddress.IsPrimary = true;
                        formInput.HomeAddress.IsNextOfKin = false;

                        formInput.WorkAddress.User = ux.Id;
                        formInput.WorkAddress.IsPrimary = false;
                        formInput.WorkAddress.IsNextOfKin = false;

                        formInput.NextOfKin.UserID = ux.Id;

                        formInput.NOKAddress.User = ux.Id;
                        formInput.NOKAddress.IsNextOfKin = true;

                        formInput.NOKContact.User = ux.Id;
                        formInput.NOKContact.IsNextOfKin = true;

                        EditUserModel currentlyStored = new EditUserModel(ux);

                        if (currentlyStored.HomeAddress == null) this._context.UserAddresseses.Add(formInput.HomeAddress); else currentlyStored.HomeAddress.UpdateMe(formInput.HomeAddress);

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
                        var newPasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(ux, formInput.Password);
                        var store = new UserStore<ApplicationUser>(this._context);
                        await store.SetPasswordHashAsync(ux, newPasswordHash);
                        this._context.SaveChanges();
                        return Redirect(successURL);
                    }
                }
            }
            return View(formInput);
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