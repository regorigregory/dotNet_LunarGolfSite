using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace LunarSports.Controllers
{
 //   [Area("Public")]
    public class DefaultController : Controller
    {
        private LunarSportsDBContext _context;
        public DefaultController(LunarSportsDBContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var HomePage = this._context.Pages.Where(p => p.Title == "Home").FirstOrDefault();
            ViewBag.Page = HomePage;
            return View();
        }

      
    

        public IActionResult Feedback([FromQuery(Name = "message")] string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}