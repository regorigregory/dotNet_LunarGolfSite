using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class EditUserModel
    {

        public EditUserModel(ApplicationUser au)
        {
            this.FirstName = au.FirstName;
            this.LastName = au.LastName;
            this.Email = au.Email;
            this.UserName = au.UserName;


            this.BIO = au.BIO;
            this.ProfilePictureURL = au.ProfilePictureURL;
            this.Gender = au.Gender;
            this.DOB = au.DOB;
            this.ProfilePictureURL = au.ProfilePictureURL;
        }

        // public Rank UserRank { get; set; }
        [Required]
        [Display(Name = "First name")]

        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]

        public string Email { get; set; }






        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]
        public DateTime DOB { get; set; }
        public bool Active { get; set; }


        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Gender")]

        public string Gender { get; set; }
        [Display(Name = "Short introduction")]

        public string BIO { get; set; }
        [Display(Name = "ProfilePictureURL - not supported yet.")]
        public string ProfilePictureURL { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password to confirm changes")]
        public string OldPassword { get; set; }

    }
}
