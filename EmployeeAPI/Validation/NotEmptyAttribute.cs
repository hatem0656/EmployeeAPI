using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Validation
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var prop = value as ICollection;
            if (prop != null && prop.Count == 0 )
            {
                return new ValidationResult($"{validationContext.DisplayName} list can not be empty");
            }

            return ValidationResult.Success;
        }
    }
}
