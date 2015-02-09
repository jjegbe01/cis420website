using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class SaleLine
    {
        public int ID { get; set; }

        [Required]
        public int SaleID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Item Item { get; set; }
    }
}