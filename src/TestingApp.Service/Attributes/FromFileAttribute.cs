using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.Attributes
{
    public class FromFileAtribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
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
