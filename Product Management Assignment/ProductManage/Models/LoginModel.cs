using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManage.Models
{

    public class LoginModel
    {
        public int id { get; set; }

        [Required]

        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Use Lower case and UpperCase Alphabets")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum 3 Characters required")]
        [DisplayName("User Name")]
        public string userName { get; set; }

        [DisplayName("Email-Id")]
        [Required(ErrorMessage = "This Field is required")]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b", ErrorMessage = "Not a Valid Email-Id")]
        public string email { get; set; }

        [DisplayName("Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Minimum 8 Characters required")]
        [Required(ErrorMessage = "This Field is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [NotMapped]

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "This Field is required")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "The password and confirmation password should match!")]
        public string confirmPassword { get; set; }
    }
}