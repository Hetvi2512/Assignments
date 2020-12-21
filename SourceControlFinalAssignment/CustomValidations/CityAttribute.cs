using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.CustomValidations
{
    public class CityAttribute : ValidationAttribute
    {
       
            public string AllowedCities { get; set; }

            public override bool IsValid(object value)
        {
            string city = value as string;
            return AllowedCities.Contains(city);
        }
        
    }
}