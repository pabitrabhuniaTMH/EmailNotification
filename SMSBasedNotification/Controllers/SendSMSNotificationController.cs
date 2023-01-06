using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using SMSNotificationServices.IRepository;
using SMSNotificationServices.ServiceHelper;
namespace SMSBasedNotification.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class SendNotificationToSmsController : ControllerBase
    {
        private readonly ISmsNotificationService _sMSNotificationService;
        private readonly NotificationLog _notificationLog;
        public SendNotificationToSmsController(ISmsNotificationService sMSNotificationService)
        {
            _notificationLog = new NotificationLog(TimeStamp.GetTimeStamp());
            _sMSNotificationService = sMSNotificationService;
        }
        [HttpPost("SendNotificationToSMS")]
        public async Task<IActionResult> SendNotificationToSMS([FromBody]SmsNotification sMSNotification)
        {
            _notificationLog.WriteLogMessage("Sending SMS notification");
            var result = await _sMSNotificationService.SendNotification(sMSNotification);
            return Ok(result);
        }
    }
}
