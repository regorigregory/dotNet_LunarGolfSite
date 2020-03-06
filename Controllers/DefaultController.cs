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
        public IActionResult Index()
        {
            return View();
        }

      
    

        public IActionResult Feedback([FromQuery(Name = "message")] string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}