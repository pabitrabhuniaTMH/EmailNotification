using NotificationEntityModels.Models;
namespace SMSNotificationServices.IRepository
{
    public interface ISmsNotificationService
    {
        public Task<ApiResponseModel> SendNotification(SmsNotification sMSNotification);
    }
}
