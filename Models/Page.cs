using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LunarSports.Models
{
    public class Page
    {
        public int PageID { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.Text)]

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DatePublished { get; set; } 

        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        public bool IsVisible { get; set; }

        //public int Author { get; set; }
        //public int LastUpdatedBy { get; set; }

    }
}
