using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace NotificationEntityModels.Models
{
    public class SmsNotification:BaseEntity
    {
        public string? NAME { get; set; }
        [IsPhoneAttribute]
        public string? PHONE { get; set; }
        public Char NOTIFICATIONTYPE { get; set; }
        public int TEMPLATENO { get; set; }
    }

    //Custom Phone Number validation
    [ExcludeFromCodeCoverage]
    public class IsPhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                if(value==null)
                    throw new InvalidDataException("Phone number should not be null");
                if (!Regex.IsMatch(value.ToString()!, "\\A[0-9]{10}\\z"))
                    return new ValidationResult("PHONE is not a valid format");
                return ValidationResult.Success!;
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }
        }
    }
}
