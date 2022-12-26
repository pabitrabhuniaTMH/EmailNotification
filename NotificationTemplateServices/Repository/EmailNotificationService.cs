using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;
using OTPServices.ServiceHelper;

namespace NotificationTemplateServices.Repository
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly IEmailNotification _emailNotification;
        private readonly NotificationLog _notificationLog;
        private readonly long _timeStamp;
        public EmailNotificationService(IEmailNotification emailNotification)
        {
            _timeStamp = TimeStamp.GetTimeStamp();
            _notificationLog = new NotificationLog(_timeStamp);
            _emailNotification =emailNotification;
        }
        #region Save Notification Template
        public ApiResponseModel SaveNotificationTemplate(EmailNotificationTemplate emailNotificationTemplate)
        {
            try
            {
                _notificationLog.WriteLogMessage("-----Services-----  Called SeveNotification");
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
                return new ApiResponseModel
                {
                    MsgHdr = new ResponseModel<BaseResponseModel>
                    {
                        Data = new BaseResponseModel
                        {
                            ID = TimeStamp.GetTimeStamp(),
                            StatusCode = 422,
                            Status = "Failed",
                            Message = "There is a internal error"
                        }
                    }
                };
            }
            catch (Exception e)
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
