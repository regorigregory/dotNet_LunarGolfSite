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

        [Display(Name = "Whom to call for additional information")]

        public int ContactDetailID { get; set; }

        [Display(Name = "Launch site's location")]

        public int Location { get; set; }

        [Display(Name = "Name of the launch site")]

        public string Name { get; set; }

        [Display(Name = "Description of the launch site")]

        public string Description { get; set; }

        [Display(Name = "Photo url for the launch site")]

        public string PhotoURL { get; set; }


    }
}
