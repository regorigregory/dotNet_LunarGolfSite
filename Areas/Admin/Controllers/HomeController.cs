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
            this.menuEntries = new LinkedList<MenuEntry>();

            this.menuEntries.AddLast(new MenuEntry { Controller = "ApplicationRoles", Action = "Index", DisplayName = "Manage roles" });
            this.menuEntries.AddLast(new MenuEntry
            {
                Controller = "Customer",
                Action = "Index",
                DisplayName = "Manage customers"
            });
            this.menuEntries.AddLast(new MenuEntry
            {
                Controller = "EventLocationContactDetails",
                Action = "Index",
                DisplayName = "Manage contact details"
            });
            this.menuEntries.AddLast(new MenuEntry
            {
                Controller = "EventLocations",
                Action = "Index",
                DisplayName = "Manage locations"
            });
            this.menuEntries.AddLast(new MenuEntry
            {
                Controller = "Events",
                Action = "Index",
                DisplayName = "Manage events"
            });
            this.menuEntries.AddLast(new MenuEntry
            {
                Controller = "EventTypes",
                Action = "Index",
                DisplayName = "Manage event types"
            });
            this.menuEntries.AddLast(new MenuEntry
            {
                Controller = "LaunchSites",
                Action = "Index",
                DisplayName = "Manage Launch sites"
            });
            this.menuEntries.AddLast(new MenuEntry { Controller = "Pages", Action = "Index", DisplayName = "Manage pages" });

        }



        public IActionResult Index()
        {
            return View(this.menuEntries);
        }

     
    }
    public class MenuEntry
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        public string DisplayName { get; set; }


    }
}
