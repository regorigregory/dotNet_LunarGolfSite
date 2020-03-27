using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LunarSports.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        // GET: /<controller>/



        public LinkedList<MenuEntry> menuEntries;
        public HomeController()
        {
           
        }



        public IActionResult Index()
        {
            return View();
        }

     
    }
    public class MenuEntry
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        public string DisplayName { get; set; }


    }
}
