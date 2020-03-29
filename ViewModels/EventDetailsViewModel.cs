using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class EventDetailsViewModel : EventListViewModel
    {
        //Event Schedule entries -> as a list

        public EventDetailsViewModel(Event dbmodel) : base(dbmodel)
        {
            this.ScheduleEntries = LunarSportsDBContext.getInstance()
                .EventScheduleEntries.Where(ese => ese.EventID == this.Dbmodel.ID)
                .Select(ese => new EventScheduleEntryViewModel(ese)).ToList();
        }
        public List<EventScheduleEntryViewModel> ScheduleEntries {get; set;}

    }
}
