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
    public class ContactDetailsController : Controller
    {
        private readonly LunarSportsDBContext _context;

        public ContactDetailsController(LunarSportsDBContext context)
        {
            _context = context;
        }

        // GET: ContactDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserContactDetails.ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userContactDetail = await _context.UserContactDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userContactDetail == null)
            {
                return NotFound();
            }

            return View(userContactDetail);
        }

        // GET: ContactDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User,IsNextOfKin,ID,ContactDetailType,Mobile,Landline,Email")] UserContactDetail userContactDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userContactDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userContactDetail);
        }

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userContactDetail = await _context.UserContactDetails.FindAsync(id);
            if (userContactDetail == null)
            {
                return NotFound();
            }
            return View(userContactDetail);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User,IsNextOfKin,ID,ContactDetailType,Mobile,Landline,Email")] UserContactDetail userContactDetail)
        {
            if (id != userContactDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userContactDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserContactDetailExists(userContactDetail.ID))
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
            return View(userContactDetail);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userContactDetail = await _context.UserContactDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userContactDetail == null)
            {
                return NotFound();
            }

            return View(userContactDetail);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userContactDetail = await _context.UserContactDetails.FindAsync(id);
            _context.UserContactDetails.Remove(userContactDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserContactDetailExists(int id)
        {
            return _context.UserContactDetails.Any(e => e.ID == id);
        }
    }
}
