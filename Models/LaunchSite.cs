using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class LaunchSite
    {
        public int ID { get; set; }


  
        public int Location { get; set; }

        [Display(Name = "Description of the launch site")]

   
        public string Description { get; set; }

        


    }
}
