using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class LaunchSite
    {

        public LaunchSite()
        {

        }
        public int ID { get; set; }



        public int Location { get; set; }

        [Display(Name = "Description of the launch site")]


        public string Description { get; set; }

        public static LaunchSite LaunchSiteFromDb(int id)
        {
            var site = LunarSportsDBContext.getInstance().LaunchSites.Where(ls => ls.ID == id).FirstOrDefault();
            return site;
        }


    }
}
