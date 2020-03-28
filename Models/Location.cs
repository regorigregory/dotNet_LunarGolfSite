using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LunarSports.Models
{
    public abstract class Location
    {

        //https://schema.org/PostalAddress
        //https://design-system.service.gov.uk/patterns/addresses/
        public Location()
        {

        }
        public int ID { get; set; }

        [Display(Name = "Building/flat name.")]

        public string LocationName { get; set; }

        [Display(Name = "Building/flat number")]

        public string BuildingNO { get; set; }

        [Display(Name = "Street address")]

        public string StreetAddress { get; set; }

        [Display(Name = "Town/city")]
        public string Locality { get; set; }

        [Display(Name = "County")]

        public string Region { get; set; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Postcode")]

        public string PostCode { get; set; }

        [Display(Name = "Country")]
        public string CountryCode { get; set; }

       
        public void UpdateMe(Location newData)
        {
            this.LocationName = newData.LocationName;
            this.BuildingNO = newData.BuildingNO;
            this.StreetAddress = newData.StreetAddress;
            this.Locality = newData.Locality;
            this.Region = newData.Region;
            this.PostCode = newData.PostCode;
            this.CountryCode = newData.CountryCode;
        }


    }
}
