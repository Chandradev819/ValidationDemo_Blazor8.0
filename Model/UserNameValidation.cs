using System.ComponentModel.DataAnnotations;

namespace ValidationDemo.Model
{
    public class UserNameValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string inputValue = value.ToString();
                if (inputValue.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult("You can give name as 'Admin'.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
