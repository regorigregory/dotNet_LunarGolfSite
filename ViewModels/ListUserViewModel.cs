using LunarSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.ViewModels
{
    public class ListUserViewModel
    {
        public ListUserViewModel()
        {

        }

        public ListUserViewModel(ApplicationUser au)
        {
            this.Id = au.Id;
            this.Username = au.UserName;
            this.Email = au.Email;
            this.FirstName = au.FirstName;
            this.LastName = au.LastName;
            this.DOB = au.DOB;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}
