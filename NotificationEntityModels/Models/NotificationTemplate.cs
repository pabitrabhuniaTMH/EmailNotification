using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEntityModels.Models
{
    public class EmailNotificationTemplate
    {
        [Required(ErrorMessage ="NotificationType is required")]
        public string NotificationType { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TemplateValidUpto { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "BodyMassage is required")]
        public string BodyMassage { get; set; }
        [Required(ErrorMessage = "RequestDevice is required")]
        public string RequestDevice { get; set; }
        [Required(ErrorMessage = "Requestion is required")]      
        public int Requestion { get; set; }

    }
    public class NotificationParams
    {
        public int ID { get; set; }
        public string NotificationType { get; set; }
        public string Type { get; set; }
        public string TemplateValidUpto { get; set; }
        public string Subject { get; set; }
        public string BodyMessage { get; set; }
        public string RequestDevice { get; set; }
        public string Requestion { get; set; }
        public string Task { get; set; }

    }
}
