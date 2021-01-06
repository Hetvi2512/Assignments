using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProductManage.Models
{
    public class ProductInfo
    {
        [Key]
        public int product_Id { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Use Lower case and UpperCase Alphabets")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum 3 Characters required")]
        [DisplayName("Product Name")]
        public string product_name { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [DisplayName("Product Price")]
        public int product_price { get; set; }
   
        [DisplayName("Product Quantity")]
        [Required(ErrorMessage = "This Field is required")]
        public int product_qnty { get; set; }

        [Required(ErrorMessage = "Choose from above category")]
        [DisplayName("Product Category")]
        public string product_category { get; set; }

        [Required(ErrorMessage = "Give a short description of product")]
        [DisplayName("Short Description")]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9\s]+$", ErrorMessage = "Use of alphabets and numbers is allowed")]
        public string short_desc { get; set; }

        [Required(ErrorMessage = "Give a long description of product")]
        [DisplayName("Long Description")]
     [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9\s]+$", ErrorMessage = "Use of alphabets and numbers is allowed")]
        public string long_desc { get; set; }

       
        [DisplayName("Upload Product Display Image")]
        [Required(ErrorMessage = "Please select an Image")]
        public  string ImagePath { get; set; }

        [NotMapped]
        [JsonIgnore]

        public HttpPostedFileBase ImageFile { get; set; }


        [DisplayName("Upload Product Descriptive Image")]
        [Required(ErrorMessage = "Please select an Image")]
        public string BigImagePath { get; set; }

        [NotMapped]
        [JsonIgnore]
    
        public HttpPostedFileBase BigImageFile { get; set; }

        public ProductInfo()
        {
            ImagePath = "~/Images/cart.jpg";
            BigImagePath = "~/Images/cart.jpg";
        }
    }
}