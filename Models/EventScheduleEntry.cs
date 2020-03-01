using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LunarSports.Models
{
    public class EventScheduleEntry
    {
        public int EventScheduleEntryID { get; set; }
        public int EventID { get; set; }
        public int LocationID { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }


        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }
    }
}
