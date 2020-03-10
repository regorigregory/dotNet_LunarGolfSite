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
    public class NextOfKinsController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public NextOfKinsController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: NextOfKins
        public async Task<IActionResult> Index()
        {
            return View(await _context.NextOfKins.ToListAsync());
        }

        // GET: NextOfKins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKins
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        // GET: NextOfKins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NextOfKins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,RelationShip")] NextOfKin nextOfKin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nextOfKin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nextOfKin);
        }

        // GET: NextOfKins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKins.FindAsync(id);
            if (nextOfKin == null)
            {
                return NotFound();
            }
            return View(nextOfKin);
        }

        // POST: NextOfKins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,RelationShip")] NextOfKin nextOfKin)
        {
            if (id != nextOfKin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nextOfKin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NextOfKinExists(nextOfKin.ID))
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
            return View(nextOfKin);
        }

        // GET: NextOfKins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKins
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        // POST: NextOfKins/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nextOfKin = await _context.NextOfKins.FindAsync(id);
            _context.NextOfKins.Remove(nextOfKin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NextOfKinExists(int id)
        {
            return _context.NextOfKins.Any(e => e.ID == id);
        }
    }
}
