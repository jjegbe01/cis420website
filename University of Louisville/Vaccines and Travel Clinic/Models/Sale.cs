using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int LocationID { get; set; }
        public int CustomerID { get; set; }

        public virtual Location Location { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleLine> SaleLines { get; set; }
    }
}