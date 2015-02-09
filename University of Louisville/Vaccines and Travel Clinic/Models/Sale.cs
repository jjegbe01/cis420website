using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Sale
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int LocationID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        public virtual Location Location { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleLine> SaleLines { get; set; }
    }
}