using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LunarSports.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int LaunchSiteID { get; set; }

        [Display(Name = "Type of the event")]

        public int EventType { get; set; }

        [Display(Name = "Title of the event")]

        public string Title { get; set; }
        public bool IsVisible { get; set; }

        [Display(Name = "Start date")]

        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End date")]

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Short Description")]

        public string Description { get; set; }

        //public string EventPhoto { get; set; }
        // public List<EventScheduleEntry> EventSchedule { get; set; }
        [Display(Name = "Maximum number of applicants")]

        public int EventUserMaxCapacity { get; set; }

        // public List<ApplicationUser> UsersSignedUp { get; set; }

    }
}
