using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LunarSports.Models
{
    public class ApplicationUser : IdentityUser
    {
  
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
  

        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string BIO { get; set; }
        public string ProfilePictureURL { get; set; }


       // public Rank UserRank { get; set; }

        public bool Active { get; set; }
        



       
        


    }
}
