using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int SupplierID { get; set; }
        public DateTime Recieved { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}