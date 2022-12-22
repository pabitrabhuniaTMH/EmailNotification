using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;
using OTPServices.ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationTemplateServices.Repository
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly IEmailNotification _emailNotification;
        public EmailNotificationService(IEmailNotification emailNotification)
        {
            _emailNotification=emailNotification;
        }
        public ApiResponseModel SaveNotificationTemplate(EmailNotificationTemplate emailNotificationTemplate)
        {
            try
            {
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
    }
}
