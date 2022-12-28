using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using SMSNotificationServices.IRepository;
using SMSNotificationServices.ServiceHelper;
namespace SMSBasedNotification.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class SendNotificationToSMSController : ControllerBase
    {
        private readonly ISMSNotificationService _sMSNotificationService;
        private readonly NotificationLog _notificationLog;
        private readonly long _timeStamp;
        public SendNotificationToSMSController(ISMSNotificationService sMSNotificationService)
        {
            _timeStamp = TimeStamp.GetTimeStamp();
            _notificationLog = new NotificationLog(_timeStamp);
            _sMSNotificationService = sMSNotificationService;
        }
        [HttpPost("SendNotificationToSMS")]
        public async Task<IActionResult> SendNotificationToSMS([FromBody]SMSNotification sMSNotification)
        {
            _notificationLog.WriteLogMessage("Sending SMS notification");
            var result = await _sMSNotificationService.SendNotification(sMSNotification);
            return Ok(result);
        }
    }
}
