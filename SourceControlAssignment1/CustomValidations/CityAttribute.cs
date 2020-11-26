using System;
using System.ComponentModel.DataAnnotations;

namespace Registration_form.CustomValidations
{
    public class CityAttribute:ValidationAttribute
    {

        protected override ValidationResult IsValid
    (object value, ValidationContext validationContext)
        {
            string city = value.ToString();

            if (city != "Rajkot" && city != "Mumbai" && city != "Delhi")
            {
                return new ValidationResult("Invalid city, Valid values are Rajkot, Mumbai, and Delhi.");
            }
            return ValidationResult.Success;
        }
    }
}