using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;
using SMSNotificationServices.ServiceHelper;

namespace NotificationTemplateServices.Repository
{
    public class EmailNotificationServices : IEmailNotificationService
    {
        private readonly IEmailNotification _emailNotification;
        private readonly NotificationLog _notificationLog;
        public EmailNotificationServices(IEmailNotification emailNotification)
        {
            _notificationLog = new NotificationLog(TimeStamp.GetTimeStamp());
            _emailNotification =emailNotification;
        }
        #region Save Notification Template
        public ApiResponseModel SaveNotificationTemplate(EmailNotificationTemplate emailNotificationTemplate)
        {
            try
            {
                _notificationLog.WriteLogMessage("-----Services-----  Called SeveNotification");
                if (emailNotificationTemplate.NotificationType != "E")
                    throw new InvalidDataException("Notification Type is invalid");
                var result = _emailNotification.SeveNotification(emailNotificationTemplate);
                if (result != 0)
                {
                    return new ApiResponseModel
                    {
                        MsgHdr = new ResponseModel<BaseResponseModel>
                        {
                            Data = new BaseResponseModel
                            {
                                ID = TimeStamp.GetTimeStamp(),
                                StatusCode = 200,
                                Status = "Success",
                                Message = "Data Has Been Successfully saved"
                            }
                        }
                    };                    
                }
                throw new InvalidDataException();
            }
            catch (InvalidDataException e)
            {
                _notificationLog.WriteLogMessage("-------------------Error-----------------\n  "+e.ToString());
                return new ApiResponseModel
                {
                    MsgHdr = new ResponseModel<BaseResponseModel>
                    {
                        Data = new BaseResponseModel
                        {
                            ID = TimeStamp.GetTimeStamp(),
                            StatusCode = 422,
                            Status = "Failed",
                            Message = e.Message
                        }
                    }
                };
            }
            

        }
        #endregion
    }
}
