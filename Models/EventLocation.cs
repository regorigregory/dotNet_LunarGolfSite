using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class EventLocation : Location
    {

        [Display(Name = "Latitude")]
        public double Lat { get; set; }

        [Display(Name = "Longitude")]

        public double Long { get; set; }


        [Display(Name = "Is on the moon?")]

        public bool IsLunarLocation { get; set; }

        [Display(Name = "Contact detail id")]

        public int ContactDetail { get; set; }
    }
}
