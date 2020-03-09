using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class EventType
    {
        public int ID { get; set; }

        [Display(Name = "Name of the schedule entry")]
        public string Name { get; set; }

        [Display(Name = "Description of the event type")]
        public string Description { get; set; }

    }
}
