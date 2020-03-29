using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class EventListViewModel
    {
    
        public EventListViewModel()
        {

        }
        public EventListViewModel(Event dbmodel)
        {
            this.Dbmodel = dbmodel;
            this.LaunchSite = new LaunchSiteViewModel(LunarSportsDBContext.getInstance().LaunchSites.Where(ls => this.Dbmodel.LaunchSiteID == ls.ID).FirstOrDefault());
        }
        public Event Dbmodel { get; set; }

        public LaunchSiteViewModel LaunchSite { get; set; }
   
 

    }
}
