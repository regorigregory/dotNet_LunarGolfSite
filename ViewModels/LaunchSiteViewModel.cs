using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class LaunchSiteViewModel
    {
        public LaunchSiteViewModel(LaunchSite dbmodel)
        {
            this.Dbmodel = dbmodel;
            this.Location = LunarSportsDBContext.getInstance().EventLocations.Where(loc => this.Dbmodel.Location==loc.ID).FirstOrDefault();
            this.Contact = LunarSportsDBContext.getInstance().EventLocationContactDetails.Where(c => c.ID == this.Location.ContactDetail).FirstOrDefault();   
        }

        public LaunchSite Dbmodel { get; set; }
        public EventLocation Location { get; set; }
        public EventLocationContactDetail Contact { get; set; }
    }
}
