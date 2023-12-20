using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestingApp.Service.Attributes
{
    public class UserPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            if (value is string password && password.Length >= 8 && password.Any(c => char.IsDigit(c))
                && password.Any(c => char.IsLetter(c))); 
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Sizning parolingiz yaroqli emas");
        }

        /*protected ValidationResult IsReliable(object value)
        {
            if (value is string password && password.Length >= 8 && password.Any(c => char.IsDigit(c))
                && password.Any(c => char.IsLetter(c))) ;
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("");
        }*/
    }
}
