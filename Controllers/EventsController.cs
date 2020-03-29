using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;
using LunarSports.ViewModels;

namespace LunarSports.Controllers
{
    public class EventsController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public EventsController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: Events
        public IActionResult Index()
        {
            var EventsPage = this._context.Pages.Where(p => p.Title == "Events").FirstOrDefault();
            ViewBag.Page = EventsPage;


            var events = _context.Events.Select(golfEvent => new EventListViewModel(golfEvent)).ToList();
       

            return View(events);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(new EventDetailsViewModel(@event));
        }

    }     
}
