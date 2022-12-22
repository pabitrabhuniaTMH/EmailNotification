using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;

namespace NotificationTemplate.Controllers
{
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class NotificationTemplateController : ControllerBase
    {
        private readonly IEmailNotificationService _emailNotificationService;
        public NotificationTemplateController(IEmailNotificationService emailNotificationService)
        {
            _emailNotificationService=emailNotificationService;
        }
        [HttpPost("SaveEmailNotificationTemplate")]
        public IActionResult SaveEmailNotificationTemplate(EmailNotificationTemplate emailNotification)
        {
            var result=_emailNotificationService.SaveNotificationTemplate(emailNotification);
            return Ok(result);
        }
    }
}
