using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;
using Microsoft.AspNetCore.Authorization;

namespace LunarSports.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class EventLocationsController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public EventLocationsController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: Admin/EventLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventLocations.ToListAsync());
        }

        // GET: Admin/EventLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocation = await _context.EventLocations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventLocation == null)
            {
                return NotFound();
            }

            return View(eventLocation);
        }

        // GET: Admin/EventLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/EventLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lat,Long,IsLunarLocation,ContactDetail,ID,LocationName,BuildingNO,StreetAddress,Locality,Region,PostCode,CountryCode")] EventLocation eventLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventLocation);
        }

        // GET: Admin/EventLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocation = await _context.EventLocations.FindAsync(id);
            if (eventLocation == null)
            {
                return NotFound();
            }
            return View(eventLocation);
        }

        // POST: Admin/EventLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lat,Long,IsLunarLocation,ContactDetail,ID,LocationName,BuildingNO,StreetAddress,Locality,Region,PostCode,CountryCode")] EventLocation eventLocation)
        {
            if (id != eventLocation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventLocationExists(eventLocation.ID))
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
            return View(eventLocation);
        }

        // GET: Admin/EventLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocation = await _context.EventLocations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventLocation == null)
            {
                return NotFound();
            }

            return View(eventLocation);
        }

        // POST: Admin/EventLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventLocation = await _context.EventLocations.FindAsync(id);
            _context.EventLocations.Remove(eventLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventLocationExists(int id)
        {
            return _context.EventLocations.Any(e => e.ID == id);
        }
    }
}
