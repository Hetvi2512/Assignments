using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace SourceControlFinalAssignment.CustomValidations
{
    public class MyFIleextension:ValidationAttribute
    {
        public string AllowedExtensions { get; set; }
        public override bool IsValid(object value)
        {
            HttpPostedFileBase myfile = value as HttpPostedFileBase;
            string ext = Path.GetExtension(myfile.FileName);
            ext = ext.TrimStart('.');
           return  AllowedExtensions.Contains(ext);
        }
    }
}