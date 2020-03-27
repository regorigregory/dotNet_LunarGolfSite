using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;
using LunarSports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;

namespace LunarSports.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class LaunchSitesController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public LaunchSitesController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: Admin/LaunchSites
        public async Task<IActionResult> Index()
        {
            var q = await (from lsite in _context.LaunchSites
                    join eLocation in _context.EventLocations on lsite.Location equals eLocation.ID
                    select new Tuple<EventLocation, LaunchSite>(eLocation, lsite)).ToListAsync();


            return View(q);

        }

        // GET: Admin/LaunchSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchSite = await _context.LaunchSites
                .FirstOrDefaultAsync(m => m.ID == id);
            if (launchSite == null)
            {
                return NotFound();
            }

            return View(launchSite);
        }

        // GET: Admin/LaunchSites/Create
        public IActionResult Create()
        {
            this.getLocations();
            return View();
        }

        // POST: Admin/LaunchSites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContactDetailID,Location,Name,Description,PhotoURL")] LaunchSite launchSite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(launchSite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(launchSite);
        }

        // GET: Admin/LaunchSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.getLocations();
            var launchSite = await _context.LaunchSites.FindAsync(id);
            if (launchSite == null)
            {
                return NotFound();
            }
            return View(launchSite);
        }

        // POST: Admin/LaunchSites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContactDetailID,Location,Name,Description,PhotoURL")] LaunchSite launchSite)
        {
            if (id != launchSite.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(launchSite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaunchSiteExists(launchSite.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(launchSite);
        }

        // GET: Admin/LaunchSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchSite = await _context.LaunchSites
                .FirstOrDefaultAsync(m => m.ID == id);
            if (launchSite == null)
            {
                return NotFound();
            }

            return View(launchSite);
        }

        // POST: Admin/LaunchSites/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launchSite = await _context.LaunchSites.FindAsync(id);
            _context.LaunchSites.Remove(launchSite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaunchSiteExists(int id)
        {
            return _context.LaunchSites.Any(e => e.ID == id);
        }
        private void getLocations()
        {
            var listedQuery = _context.EventLocations.Select(lsite => new LocationSelect { ID = lsite.ID, Name = lsite.LocationName }).ToList();

            ViewBag.eventLocations = listedQuery;
           
        }
    }
}
