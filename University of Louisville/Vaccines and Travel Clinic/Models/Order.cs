using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int SupplierID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Recieved { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}