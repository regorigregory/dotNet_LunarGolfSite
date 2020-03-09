using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LunarSports.ViewComponents
{
    [ViewComponent(Name = "GetMenuEntries")]
    public  class MenuComponent : ViewComponent

    {
        private readonly LunarSportsDBContext _context;

        public MenuComponent(LunarSportsDBContext context)
        {
            _context = context;
        }

      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loadedPages = await _context.Pages.ToListAsync();

            return View(loadedPages);
        }
    }
}