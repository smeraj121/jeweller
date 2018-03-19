using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace jeweller.Models
{
    public class JewellerDetails
    {
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact1 { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact2 { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Pincode { get; set; }
    }
}