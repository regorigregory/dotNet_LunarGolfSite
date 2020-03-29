using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class EventScheduleEntryViewModel
    {
        public EventScheduleEntryViewModel(EventScheduleEntry dbModel)
        {
            this.Dbmodel = dbModel;

            var dbLoc = LunarSportsDBContext.getInstance().EventLocations.Where(el=>el.ID ==this.Dbmodel.LocationID ).FirstOrDefault();

            this.Location = new EventLocationViewModel(dbLoc);
        }
        public EventScheduleEntry Dbmodel { get; set; }
        public EventLocationViewModel Location { get; set; }


    }
}
