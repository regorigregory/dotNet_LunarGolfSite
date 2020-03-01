using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using LunarSports.Models;

namespace LunarSports.Controllers
{
    public class RankController : Controller
    {
        LunarSportsDBContext _context;
        public RankController(LunarSportsDBContext dbctx)
        {
            this._context = dbctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.test = "hello";

            return View();
        }


        [HttpPost]
        public ViewResult Create(Rank rank)
        {
                
                ViewBag.test = rank.RankName.ToString();
            this._context.Add<Rank>(rank);
            this._context.SaveChanges();
            return View();
        }

        public ViewResult List()
        {
            return View();
        }


    }
}