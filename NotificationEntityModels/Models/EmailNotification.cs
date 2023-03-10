using System.ComponentModel.DataAnnotations;

namespace NotificationEntityModels.Models
{

    public class EmailNotification
    {
        [Required(ErrorMessage = "NotifyTo is required")]
        public NotifyTo? NotifyTo { get; set; }
        [Required(ErrorMessage = "NotificationType is required")]
        public Char? NotificationType { get; set; }
        [Required(ErrorMessage = "NotificationTemplateId is required")]
        public string? NotificationTemplateId { get; set; }

    }
    public class NotifyTo:BaseEntity
    {
        [Required(ErrorMessage = "NAME is required")]
        public string? NAME { get; set; }
        [Required(ErrorMessage ="Email should not be null")]
        public string? EMAIL { get; set; }
    }

    //For notification type
    public enum NFType
    {
        SMS='S',
        EMAIL='E',
        WHATSAPP='W'
    }

}
