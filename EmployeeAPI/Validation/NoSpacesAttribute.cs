using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Validation
{
    public class NoSpacesAttribute : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           var prop = value as string;
           if(prop != null && prop.Contains(' '))
            {
                return new ValidationResult($"{validationContext.DisplayName} must not contain whitespaces");
            }

           return ValidationResult.Success;
        }
    }
}
