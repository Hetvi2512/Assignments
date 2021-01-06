using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManage.Dtos
{
    public class ProductDto
    {
        public int product_Id { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Use Lower case and UpperCase Alphabets")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum 3 Characters required")]
      
        public string product_name { get; set; }

        [Required(ErrorMessage = "This Field is required")]
       
        public int product_price { get; set; }

       
        [Required(ErrorMessage = "This Field is required")]
        public int product_qnty { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string product_category { get; set; }


        [Required(ErrorMessage = "Give a short description of product")]
        public string short_desc { get; set; }

        [Required(ErrorMessage = "Give a long description of product")]
        public string long_desc { get; set; }
        public string ImagePath { get; set; }

        public string BigImagePath { get; set; }
      

    }
}