using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class LaunchSite
    {
        public int LaunchSiteID { get; set; }
        public int ContactDetailID { get; set; }

        public Location Location { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }


    }
}
