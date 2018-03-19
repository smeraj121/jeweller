using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jeweller.Models
{
    public class CustomerModel
    {
        [Display(Name = "Customer Id")][Key]
        public int Cust_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Pincode { get; set; }
    }
    //public class SearchModel
    //{
    //    string Search_value { get; set; }
    //}

    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Display(Name = "Product")][Required]
        public string Product_Name { get; set; }

        [Display(Name ="Weight(mg)")]
        [Required]
        public float Weight { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid decimal Number")]
        public float Purity { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Desc { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid decimal Number")]
        public float Rate { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid decimal Number")]
        public float Price { get; set; }
    }

    public class combined
    {
        public CustomerModel customer { set; get; }
        public Product productmodel { get; set; }
    }
}