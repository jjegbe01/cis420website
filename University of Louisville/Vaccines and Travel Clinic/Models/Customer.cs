using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Origin { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}