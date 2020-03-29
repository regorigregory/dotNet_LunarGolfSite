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

        private LunarSportsDBContext _context;
          
        public EditUserModel()
        {

        }
        public EditUserModel(ApplicationUser au) {
            this._context = LunarSportsDBContext.getInstance();
            this.SetApplicationUserDetails(au);
            this.GetAdditionalUserDetails();
        }

        public void SetApplicationUserDetails(ApplicationUser au)
        {
            if (au != null)
            {
                this.Id = au.Id;
                this.FirstName = au.FirstName;
                this.LastName = au.LastName;
                this.Email = au.Email;


                this.BIO = au.BIO;
                this.ProfilePictureURL = au.ProfilePictureURL;
                this.Gender = au.Gender;
                this.DOB = au.DOB;
                this.ProfilePictureURL = au.ProfilePictureURL;
            }
        }

        public void GetAdditionalUserDetails()
        {
            this.HomeContact = this._context.UserContactDetails.Where(x=>x.User == this.Id & x.IsNextOfKin==false & x.IsPrimary==true).FirstOrDefault();
            this.WorkContact = this._context.UserContactDetails.Where(x => x.User == this.Id & x.IsNextOfKin == false & x.IsPrimary ==false).FirstOrDefault(); ;
            this.NOKContact = this._context.UserContactDetails.Where(x => x.User == this.Id & x.IsNextOfKin == true).FirstOrDefault();

            this.HomeAddress = this._context.UserAddresseses.Where(x => x.User == this.Id & x.IsNextOfKin == false & x.IsPrimary == true).FirstOrDefault();
            this.WorkAddress = this._context.UserAddresseses.Where(x => x.User == this.Id & x.IsNextOfKin == false & x.IsPrimary == false).FirstOrDefault(); ;
            this.NOKAddress = this._context.UserAddresseses.Where(x => x.User == this.Id & x.IsNextOfKin == true).FirstOrDefault(); ;
            this.NextOfKin = this._context.NextOfKins.Where(x => x.UserID == this.Id).FirstOrDefault();
        }
        public NextOfKin NextOfKin{get; set;}
        public UserAddress NOKAddress { get; set; }

        public UserContactDetail NOKContact { get; set; }

        public UserAddress HomeAddress { get; set; }
        public UserAddress WorkAddress { get; set; }

        public UserContactDetail HomeContact { get; set; }

        public UserContactDetail WorkContact { get; set; }


        public string Id { get; set; }


        // public Rank UserRank { get; set; }
        [Display(Name = "First name")]

        public string FirstName { get; set; }

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
