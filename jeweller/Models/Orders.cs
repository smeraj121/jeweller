using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jeweller.Models
{
    public class Orders
    {
        [Display(Name = "Order No.")]
        public int orders_id { get; set; }

        [Display(Name = "Product Id")]
        public int product_id { get; set; }

        [Display(Name = "Customer Id")]
        public int order_id { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Total")]
        public float Order_price { get; set; }
    }
}