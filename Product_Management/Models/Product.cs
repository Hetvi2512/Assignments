using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_Management.Models
{
    public class Product
    {
        [Key]
        public int product_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum 3 Characters required")]
        public string product_name { get; set; }

        [Required]
        public int product_price { get; set; }
    }
}