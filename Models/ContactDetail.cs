using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public abstract class ContactDetail
    {

        public int ID { get; set; }

        public bool IsPrimary { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile number")]
        public string Mobile { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Landline phone number (optional")]
         public string Landline { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Additional email address")]
        public string Email { get; set; }

        public void UpdateMe(ContactDetail newData)
        {
            this.Mobile = newData.Mobile;
            this.Landline = newData.Landline;
            this.Email = newData.Email;
        }
       




    }
}
