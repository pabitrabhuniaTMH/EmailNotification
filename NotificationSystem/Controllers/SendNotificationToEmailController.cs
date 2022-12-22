using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;
using OTPServices.ServiceHelper;

namespace NotificationSystem.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class SendNotificationToEmailController : ControllerBase
    {
        private readonly IEmailNotificationServices _emailNotificationServices;
        private readonly NotificationLog _notificationLog;
        private readonly long _timeStamp;
        public SendNotificationToEmailController(IEmailNotificationServices emailNotificationServices)
        {
            _timeStamp = TimeStamp.GetTimeStamp();
            _notificationLog = new NotificationLog(_timeStamp);
            _emailNotificationServices = emailNotificationServices;
        }
        [HttpPost]
        [Route("SendNotificationToEmail")]
        public IActionResult SendNotificationToEmail(EmailNotification emailNotification)
        {
            _notificationLog.WriteLogMessage("SendNotification started------Controller: SendNotification");
            var result = _emailNotificationServices.SendNotification(emailNotification);
            return Ok(result);
        }
    }
}
