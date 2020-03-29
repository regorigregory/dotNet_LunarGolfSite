using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class EventLocationViewModel
    {
        public EventLocationViewModel(EventLocation dbmodel)
        {
            this.Dbmodel = dbmodel;
            this.Contact = LunarSportsDBContext.getInstance().
                EventLocationContactDetails.Where(elcd => elcd.ID == this.Dbmodel.ContactDetail).FirstOrDefault();
            }

        public EventLocation Dbmodel { get; set; }
        public EventLocationContactDetail Contact { get; set; }

      
    }
}
