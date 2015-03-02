using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        public string Secure_City { get; set; }

        [Required]
        public string Secure_State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Secure_Zip { get; set; }

        [Required]
        public string Secure_Country { get; set; }

        [Required]
        public string Secure_Race { get; set; }

        [Required]
        public int Secure_Age { get; set; }

        [Required]
        public string Secure_Gender { get; set; }

        [Required]
        public string Secure_Origin { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        [Display(Name = "Address")]
        public string DisplayAddress
        {

            get
            {
                string dspCity = string.IsNullOrWhiteSpace(this.Secure_City) ? "" : this.Secure_City;
                string dspState = string.IsNullOrWhiteSpace(this.Secure_State) ? "" : this.Secure_State;
                string dspZip = string.IsNullOrWhiteSpace(this.Secure_Zip) ? "" : this.Secure_Zip;
                string dspCountry = string.IsNullOrWhiteSpace(this.Secure_Country) ? "" : this.Secure_Country;

                return string.Format("{0} {1} {2}, {3}", dspCity, dspState, dspZip, dspCountry);
            }

        }
    }
}