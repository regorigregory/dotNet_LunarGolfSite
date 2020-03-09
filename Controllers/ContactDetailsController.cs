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
            return View(await _context.ContactDetails.ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetail = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.ContactDetailID == id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return View(contactDetail);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactDetailID,ContactDetailType,Mobile,Landline,Email,User")] ContactDetail contactDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactDetail);
        }

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetail = await _context.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }
            return View(contactDetail);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactDetailID,ContactDetailType,Mobile,Landline,Email,User")] ContactDetail contactDetail)
        {
            if (id != contactDetail.ContactDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailExists(contactDetail.ContactDetailID))
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
            return View(contactDetail);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetail = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.ContactDetailID == id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return View(contactDetail);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDetail = await _context.ContactDetails.FindAsync(id);
            _context.ContactDetails.Remove(contactDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactDetailExists(int id)
        {
            return _context.ContactDetails.Any(e => e.ContactDetailID == id);
        }
    }
}
