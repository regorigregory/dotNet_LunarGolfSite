using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class AdminEditUserModel :EditUserModel
    {
        public AdminEditUserModel()
        {

        }

        public AdminEditUserModel(ApplicationUser au) : base(au)
        {

        }

        public string SpecRole { get; set; }

    }
}
