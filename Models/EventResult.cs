using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class EventResult
    {
        public int EventResultID { get; set; }
        public Event EventID { get; set; }
        public Dictionary<string, string> ResultKeyValue { get; set; }

    }
}
