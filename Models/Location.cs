using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public class Location
    {

        //https://schema.org/PostalAddress
        //https://design-system.service.gov.uk/patterns/addresses/

        public int LocationID { get; set; }
        public string LocationName { get; set; }


        public string BuildingNO { get; set; }
        public string StreetAddress { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }

        public string PostCode { get; set; }
        public string CountryCode { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }

        public bool IsLunarLocation { get; set; }

        public int ContactDetail { get; set; }



    }
}
