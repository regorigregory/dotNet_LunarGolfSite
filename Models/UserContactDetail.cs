﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class UserContactDetail : ContactDetail
    {
        public UserContactDetail()
        {
            
        }
        public string User { get; set; }
        public bool IsNextOfKin { get; set; }
    }
}
