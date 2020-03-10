using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LunarSports.Areas.Admin.Controllers
{
    public class ImportSampleDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}