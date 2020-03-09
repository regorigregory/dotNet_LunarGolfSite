using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;

namespace LunarSports.Controllers
{
    public class LaunchSitesController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public LaunchSitesController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: LaunchSites
        public async Task<IActionResult> Index()
        {
            return View(await _context.LaunchSites.ToListAsync());
        }

        // GET: LaunchSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchSite = await _context.LaunchSites
                .FirstOrDefaultAsync(m => m.LaunchSiteID == id);
            if (launchSite == null)
            {
                return NotFound();
            }

            return View(launchSite);
        }

        // GET: LaunchSites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LaunchSites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaunchSiteID,ContactDetailID,Location,Name,Description,PhotoURL")] LaunchSite launchSite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(launchSite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(launchSite);
        }

        // GET: LaunchSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchSite = await _context.LaunchSites.FindAsync(id);
            if (launchSite == null)
            {
                return NotFound();
            }
            return View(launchSite);
        }

        // POST: LaunchSites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaunchSiteID,ContactDetailID,Location,Name,Description,PhotoURL")] LaunchSite launchSite)
        {
            if (id != launchSite.LaunchSiteID)
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
                    if (!LaunchSiteExists(launchSite.LaunchSiteID))
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

        // GET: LaunchSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchSite = await _context.LaunchSites
                .FirstOrDefaultAsync(m => m.LaunchSiteID == id);
            if (launchSite == null)
            {
                return NotFound();
            }

            return View(launchSite);
        }

        // POST: LaunchSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launchSite = await _context.LaunchSites.FindAsync(id);
            _context.LaunchSites.Remove(launchSite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaunchSiteExists(int id)
        {
            return _context.LaunchSites.Any(e => e.LaunchSiteID == id);
        }
    }
}
