using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Areas.Admin.Controllers;
using LunarSports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LunarSports.ViewComponents
{
    [ViewComponent(Name = "GetMenuEntries")]
    public  class MenuComponent : ViewComponent

    {
        private readonly LunarSportsDBContext _context;
        private readonly LinkedList<MenuEntry> menuEntries;

        public MenuComponent(LunarSportsDBContext context)
        {
            _context = context;

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

      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loadedPages = await _context.Pages.ToListAsync();
            ViewBag.adminMenuEntries = this.menuEntries;
            return View(loadedPages);
        }
    }
}