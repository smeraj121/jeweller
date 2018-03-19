using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jeweller.Models
{
    public class Products
    {
            [Key][Required]
            int Product_Id { get; set; }
        [Required]
            string Product_Name { get; set; }
        [Required]
            float Weight { get; set; }
        [Required]
            float Purity { get; set; }
        [Required]
            string Desc { get; set; }
        [Required]
            float Rate { get; set; }
        [Required]
            int Bill_Id { get; set; }
    }
}