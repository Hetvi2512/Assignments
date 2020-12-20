using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SourceControlFinalAssignment.CustomValidations;

namespace SourceControlFinalAssignment.Models
{
    public class User
    {

        public int id { get; set; }

        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Use Lower case and UpperCase Alphabets")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum 3 Characters required")]
        [DisplayName ("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Use Lower case and UpperCase Alphabets")]
        public string lastName { get; set; }

        [Range(1, 100)]
        [DisplayName("Age")]
        public int age { get; set; }


        [DisplayName("Email-Id")]
        [Required(ErrorMessage = "This Field is required")]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b", ErrorMessage = "Not a Valid Email-Id")]
        public string email { get; set; }


        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "This Field is required")]
        [Phone(ErrorMessage ="Not a valid phone number")]
        public string mobile_no { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [City]
        public string City { get; set; }

        [DisplayName("Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Minimum 8 Characters required")]
        [Required(ErrorMessage = "This Field is required")]
         [DataType(DataType.Password)]
        public string password { get; set; }


        [NotMapped]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "This Field is required")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="The password and confirmation password should match!")]
        public string confirmPassword { get; set; }


        [FileExtensions(Extensions = "png,jpg,gif,jpeg")]
        [Required(ErrorMessage = "Please select an image")]
        [DisplayName("Upload Image")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase FileName { get; set; } 

    }
}