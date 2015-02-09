using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        
        [Required]
        public string Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [Display(Name = "Address")]
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