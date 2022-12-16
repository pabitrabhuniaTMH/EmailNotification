using NotificationEntityModels.Models;

namespace NotificationServices.IRepository
{
    public interface IEmailNotificationServices
    {
        public ApiResponseModel SendNotification(EmailNotification emailNotification);
    }
}
