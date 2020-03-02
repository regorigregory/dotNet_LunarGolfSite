using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunarSports.Models;
using LunarSports.ViewModels;

namespace LunarSports.Controllers
{
    public class RegisterUserController : Controller
    {
      public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       public IActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel formInput)
        {
            Boolean isValid = ModelState.IsValid;
             ViewData["test"] = isValid.ToString();
            if (!isValid)
            {
                Console.Write("The provided model is not valid");
            }
            Console.Write("The provided model is valid");

            return View();

        }


    }
}
