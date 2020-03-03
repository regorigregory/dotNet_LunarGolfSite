using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class RegisterUserModel
    {   
        [Required]
        [Display(Name = "First name")]

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]

        public string LastName { get; set; }

        [Required]
        [Display(Name = "User name")]

        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage="Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
       
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]

        public DateTime DOB { get; set; }
        [Required]
        public string SpecRole { get; set; }

    }
}
