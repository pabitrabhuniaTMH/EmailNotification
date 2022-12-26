using NotificationEntityModels.Models;

namespace NotificationServices.IRepository
{
    public interface IEmailNotificationServices
    {
        public Task<ApiResponseModel> SendNotification(EmailNotification emailNotification);
    }
}
