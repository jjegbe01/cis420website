using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Location
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        [Display(Name="Address")]
        public string DisplayAddress
        {

            get
            {

                string dspAddress = string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
                string dspCity = string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
                string dspState = string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
                string dspZip = string.IsNullOrWhiteSpace(this.Zip) ? "" : this.Zip;
                string dspCountry = string.IsNullOrWhiteSpace(this.Country) ? "" : this.Country;

                return string.Format("{0} {1} {2} {3}, {4}", dspAddress, dspCity, dspState, dspZip, dspCountry);
            }

        }
    }
}