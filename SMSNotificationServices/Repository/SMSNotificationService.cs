using Microsoft.Extensions.Configuration;
using NotificationEntityModels.Models;
using OTPServices.ServiceHelper;
using SMSNotificationServices.IRepository;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace SMSNotificationServices.Repository
{
    public class SMSNotificationService : ISMSNotificationService
    {
        private readonly string? _accountSID;
        private readonly string? _authToken;
        private readonly string? _fromPhone;
        public SMSNotificationService(IConfiguration configuration)
        {
            _accountSID = configuration.GetSection("SMSService").GetSection("AccountSID").Value;
            _authToken = configuration.GetSection("SMSService").GetSection("AuthToken").Value;
            _fromPhone= configuration.GetSection("SMSService").GetSection("FromPhone").Value;
        }
        #region SendNotification
        public ApiResponseModel SendNotification(SMSNotification sMSNotification)
        {
            try
            {
                if (sMSNotification.PHONE == null && sMSNotification.PHONE == "")
                    throw new Exception("Phone Number should not be null");
                TwilioClient.Init(_accountSID, _authToken);
                var message = MessageResource.Create(from: new Twilio.Types.PhoneNumber(_fromPhone), 
                    body: sMSNotification.MSGBODY, to: new Twilio.Types.PhoneNumber("+91" + sMSNotification.PHONE));
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        StatusCode = 200,
                        Status = "Success",
                        Message = "SMS Notification Successfully Sent"
                    },
                    MsgBdy = new ResponseModel<string> { Data = message.Sid },
                };
            }
            catch (Exception e)
            {
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        StatusCode = 422,
                        Status = "Failed",
                        Message = e.Message
                    }
                };
            }
            
        }
        #endregion 
    }
}
