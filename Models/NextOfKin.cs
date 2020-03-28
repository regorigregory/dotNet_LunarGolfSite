using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class NextOfKin
    {

        public int ID { get; set; }

        [Display(Name = "First name of your Next of Kin")]
        [Required]
        public string FirstName { get; set; }
       
        [Required]
        [Display(Name = "Last name of your Next of Kin")]
         public string LastName { get; set; }

        [Required]
        [Display(Name = "Relationship with this person")]

        public string RelationShip { get; set; }
        public string UserID { get; set; }
       
        public void UpdateMe(NextOfKin newData)
        {
            this.FirstName = newData.FirstName;
            this.LastName = newData.LastName;
            this.RelationShip = newData.RelationShip;
        }

    }
}
