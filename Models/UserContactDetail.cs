using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class UserContactDetail : ContactDetail
    {
        public int User { get; set; }
        public bool IsNextOfKin { get; set; }
    }
}
