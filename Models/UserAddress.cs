using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class UserAddress : Location
    {
        public string User { get; set; }
        public bool IsNextOfKin { get; set; }
        public bool IsPrimary { get; set; }

    }
}
