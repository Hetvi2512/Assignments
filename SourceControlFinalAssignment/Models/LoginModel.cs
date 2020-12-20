using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.Models
{
    [NotMapped]
    public class LoginModel
    {
        [DisplayName("Email-Id")]
        [Required(ErrorMessage = "This Field is required")]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b", ErrorMessage = "Not a Valid Email-Id")]
        public string email { get; set; }


        [DisplayName("Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Minimum 8 Characters required")]
        [Required(ErrorMessage = "This Field is required")]
        [DataType(DataType.Password)]
        public string password { get;  set; }

    }
}