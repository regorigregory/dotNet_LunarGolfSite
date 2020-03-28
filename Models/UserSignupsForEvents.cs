using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class UserSignupsForEvents
    {

        public int EventID { get; set; }
        public string UserID { get; set; }
    }
}
