using Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string newName = value.ToString();
            LibEntity context = new LibEntity();
            Reader Reder = context.Readers.FirstOrDefault(r => r.Name == newName);
            if (Reder != null)
            {
                return new ValidationResult("Name Must Be Unique");
            }
            return ValidationResult.Success;
        }
    }
}
