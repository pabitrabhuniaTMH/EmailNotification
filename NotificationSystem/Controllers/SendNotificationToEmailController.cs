using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;

namespace NotificationSystem.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class SendNotificationToEmailController : ControllerBase
    {
        private readonly IEmailNotificationServices _emailNotificationServices;
        public SendNotificationToEmailController(IEmailNotificationServices emailNotificationServices)
        {
            _emailNotificationServices=emailNotificationServices;
        }
        [HttpPost]
        [Route("SendNotification")]
        public IActionResult SendNotification(EmailNotification emailNotification)
        {
            var result = _emailNotificationServices.SendNotification(emailNotification);
            return Ok(result);
        }
    }
}
