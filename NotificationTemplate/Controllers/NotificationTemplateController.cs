using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;
using SMSNotificationServices.ServiceHelper;

namespace NotificationTemplate.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class NotificationTemplateController : ControllerBase
    {
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly ITemplateServices _templateServices;
        private readonly NotificationLog _notificationLog;
        public NotificationTemplateController(IEmailNotificationService emailNotificationService,ITemplateServices templateServices)
        {
            _notificationLog = new NotificationLog(TimeStamp.GetTimeStamp());
            _emailNotificationService =emailNotificationService;
            _templateServices=templateServices;
        }
        [HttpPost("SaveEmailNotificationTemplate")]
        public IActionResult SaveEmailNotificationTemplate([FromBody]EmailNotificationTemplate emailNotification)
        {
            _notificationLog.WriteLogMessage("-----Save Email notification---- Controller Name: SaveEmailNotificationTemplate");
            var result=_emailNotificationService.SaveNotificationTemplate(emailNotification);
            return Ok(result);
        }
        [HttpGet("GetNotificationTemplate")]
        public IActionResult GetNotificationTemplate(string Type,int NotificationId)
        {
            var result = _templateServices.GetTemplateByType(Type, NotificationId);
            return Ok(result);
        }
    }
}
