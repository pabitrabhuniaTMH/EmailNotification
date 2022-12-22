using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using SMSNotificationServices.IRepository;

namespace SMSBasedNotification.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class SendNotificationToSMSController : ControllerBase
    {
        private readonly ISMSNotificationService _sMSNotificationService;
        public SendNotificationToSMSController(ISMSNotificationService sMSNotificationService)
        {
            _sMSNotificationService= sMSNotificationService;
        }
        [HttpPost("SendNotificationToSMS")]
        public IActionResult SendNotificationToSMS(SMSNotification sMSNotification)
        {
            var result = _sMSNotificationService.SendNotification(sMSNotification);
            return Ok(result);
        }
    }
}
