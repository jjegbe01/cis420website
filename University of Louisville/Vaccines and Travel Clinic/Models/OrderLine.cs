using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class OrderLine
    {
        public int ID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}