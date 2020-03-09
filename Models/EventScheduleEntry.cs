using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LunarSports.Models
{
    public class EventScheduleEntry
    {
        public int ID { get; set; }

        [Display(Name = "The event it is associated with")]

        public int EventID { get; set; }

        [Display(Name = "The location it is associated with")]

        public int LocationID { get; set; }

        [Display(Name = "Title of the entry")]

        public string Title { get; set; }

        [Display(Name = "Description of the entry")]

        public string Description { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }
    }
}
