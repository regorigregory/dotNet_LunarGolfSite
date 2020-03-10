using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LunarSports.Areas.Admin.Controllers
{
    public class CSVImportController : Controller
    {

        private readonly LunarSportsDBContext _context;
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public RoleManager<IdentityRole> roleManager { get; }


        public CSVImportController(LunarSportsDBContext dbctx, UserManager<ApplicationUser> um, SignInManager<ApplicationUser> sim, RoleManager<IdentityRole> rm)

        {
            userManager = um;
            signInManager = sim;
            roleManager = rm;
            _context = dbctx;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PopulateUsers()
        {
            return View();
        }
        public IActionResult PopulateNextOfKin()
        {
            return View();
        }
        public IActionResult PopulateUserContacts()
        {
            return View();
        }

        public IActionResult PopulateUserAddress()
        {
            return View();
        }

        public IActionResult USerSignUpsForEvents()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult EventLocations()
        {
            return View();
        }
        public IActionResult EventScheduleEntries()
        {
            return View();
        }
        
        public IActionResult EventTypes()
        {
            return View();
        }
        public IActionResult EventContacts()
        {
            return View();
        }
    
    }
}