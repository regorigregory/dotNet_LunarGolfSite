using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LunarSports.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public int LaunchSiteID { get; set; }
        public EventType EventType { get; set; }


        public string Name { get; set; }
        public bool IsVisible { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string EventPhoto { get; set; }
        public List<EventScheduleEntry> EventSchedule { get; set; }
        public int EventUserMaxCapacity { get; set; }

        public List<ApplicationUser> UsersSignedUp { get; set; }





    }
}
