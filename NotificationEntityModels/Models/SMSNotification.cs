using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotificationEntityModels.Models
{
    public class SMSNotification:BaseEntity
    {
        public string NAME { get; set; }
        [IsPhone]
        public string PHONE { get; set; }
        public Char NOTIFICATIONTYPE { get; set; }
        public int TEMPLATENO { get; set; }
    }

    //Custom Phone Number validation
    public class IsPhone : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                if (!Regex.IsMatch(value.ToString(), "\\A[0-9]{10}\\z"))
                    return new ValidationResult("PHONE is not a valid format");
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }
        }
    }
}
