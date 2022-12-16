using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEntityModels.Models
{
    public class EmailNotification
    {
        public NotifyTo NotifyTo { get; set; }
        public EmailTemplate EmailTemplate { get; set; }    
    }
    public class NotifyTo:BaseEntity
    {
        [Required(ErrorMessage = "NAME is required")]
        public string NAME { get; set; }
        [Required(ErrorMessage ="Email should not be null")]
        public string EMAIL { get; set; }
    }
    public class EmailTemplate
    {
        [Required(ErrorMessage = "EMAILSUBJECT is required")]
        public string EMAILSUBJECT { get; set; }
        [Required(ErrorMessage = "EMAILBODY is required")]
        public string EMAILBODY { get; set; }
    }
    public class EmailResponse
    {
        public string STATUS { get; set; }
        public string STATUSCODE { get; set; }
        public string MESSAGE { get; set; }
    }

}
