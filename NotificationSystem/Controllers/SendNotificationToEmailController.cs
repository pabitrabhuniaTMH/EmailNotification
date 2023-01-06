using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;
using SMSNotificationServices.ServiceHelper;

namespace NotificationSystem.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class SendNotificationToEmailController : ControllerBase
    {
        private readonly IEmailNotificationServices _emailNotificationServices;
        private readonly NotificationLog _notificationLog;
        public SendNotificationToEmailController(IEmailNotificationServices emailNotificationServices)
        {
            _notificationLog = new NotificationLog(TimeStamp.GetTimeStamp());
            _emailNotificationServices = emailNotificationServices;
        }
        [HttpPost]
        [Route("SendNotificationToEmail")]
        public async Task<IActionResult> SendNotificationToEmail([FromBody]EmailNotification emailNotification)
        {
            _notificationLog.WriteLogMessage("SendNotification started------Controller: SendNotification");
            var result = await _emailNotificationServices.SendNotification(emailNotification);
            return Ok(result);            
        }
    }
}
