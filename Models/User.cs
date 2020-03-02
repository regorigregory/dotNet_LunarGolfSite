using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LunarSports.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string BIO { get; set; }
        public string ProfilePictureURL { get; set; }


        public Rank UserRank { get; set; }

        public bool Active { get; set; }
        



       
        


    }
}
