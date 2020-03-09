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

        [Display(Name = "Will be a dropdown")]

        public int ContactDetailType { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile number")]
        [Required]
        public string Mobile { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Landline phone number (optional")]
         public string Landline { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Additional email address")]
        public string Email { get; set; }

       




    }
}
