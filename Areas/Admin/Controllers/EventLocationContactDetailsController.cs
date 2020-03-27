using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;

namespace LunarSports.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventLocationContactDetailsController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public EventLocationContactDetailsController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: Admin/EventLocationContactDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventLocationContactDetails.ToListAsync());
        }

        // GET: Admin/EventLocationContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocationContactDetail = await _context.EventLocationContactDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventLocationContactDetail == null)
            {
                return NotFound();
            }

            return View(eventLocationContactDetail);
        }

        // GET: Admin/EventLocationContactDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/EventLocationContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactName,ID,IsPrimary,Mobile,Landline,Email")] EventLocationContactDetail eventLocationContactDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventLocationContactDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventLocationContactDetail);
        }

        // GET: Admin/EventLocationContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocationContactDetail = await _context.EventLocationContactDetails.FindAsync(id);
            if (eventLocationContactDetail == null)
            {
                return NotFound();
            }
            return View(eventLocationContactDetail);
        }

        // POST: Admin/EventLocationContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactName,ID,IsPrimary,Mobile,Landline,Email")] EventLocationContactDetail eventLocationContactDetail)
        {
            if (id != eventLocationContactDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventLocationContactDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventLocationContactDetailExists(eventLocationContactDetail.ID))
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
            return View(eventLocationContactDetail);
        }

        // GET: Admin/EventLocationContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocationContactDetail = await _context.EventLocationContactDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventLocationContactDetail == null)
            {
                return NotFound();
            }

            return View(eventLocationContactDetail);
        }

        // POST: Admin/EventLocationContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventLocationContactDetail = await _context.EventLocationContactDetails.FindAsync(id);
            _context.EventLocationContactDetails.Remove(eventLocationContactDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventLocationContactDetailExists(int id)
        {
            return _context.EventLocationContactDetails.Any(e => e.ID == id);
        }
    }
}
