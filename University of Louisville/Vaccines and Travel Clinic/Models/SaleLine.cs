using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class SaleLine
    {
        public int ID { get; set; }
        public int SaleID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Item Item { get; set; }
    }
}