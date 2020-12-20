using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.CustomValidations
{
    public class CityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid
   (object value, ValidationContext validationContext)
        {
            string city = value.ToString();

            if (city != "Rajkot" && city != "Ahemdabad" && city != "Mumbai" && city != "Delhi")
            {
                return new ValidationResult("Invalid city, Valid values are Rajkot, Mumbai, and Delhi.");
            }
            return ValidationResult.Success;
        }
    }
}