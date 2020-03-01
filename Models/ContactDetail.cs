using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class ContactDetail
    {

        public int ContactDetailID { get; set; }
        public ContactDetailType ContactDetailType { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Email { get; set; }
        public User User { get; set; }





    }
}
