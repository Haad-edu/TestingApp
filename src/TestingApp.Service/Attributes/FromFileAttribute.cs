using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Service.Extantions
{
    public class FromFileAtribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is IFormFile file)
            {
                string[] extensions = new string[] { ".png", ".jpg", ".gif", ".pptx", ".ppt", ".doc", ".docx" };
                var extention = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extention.ToLower()))
                {
                    return new ValidationResult("This file extension is not allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
