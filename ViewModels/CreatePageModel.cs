using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LunarSports.ViewModels
{
    public class CreatePageModel
    {
        public string Title { get; set; }
        [DataType(DataType.Text)]

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        //public int Author { get; set; }
        //public int LastUpdatedBy { get; set; }

    }
}
