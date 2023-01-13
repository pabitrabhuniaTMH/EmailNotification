using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NotificationEntityModels.Models;
using SMSNotificationServices.ServiceHelper;
using SMSNotificationServices.IRepository;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace SMSNotificationServices.Repository
{
    public class SmsNotificationService : ISmsNotificationService
    {
        public readonly IConfiguration? _configuration;
        private  readonly string? apiBaseUrl;
        private  readonly HttpClient _httpClient = new();
        private readonly string? _accountSID;
        private readonly string? _authToken;
        private readonly string? _fromPhone;
        private readonly NotificationLog _notificationLog;
        public SmsNotificationService(IConfiguration configuration)
        {
            _notificationLog = new NotificationLog(TimeStamp.GetTimeStamp());
            _accountSID = configuration.GetSection("SMSService").GetSection("AccountSID").Value;
            _authToken = configuration.GetSection("SMSService").GetSection("AuthToken").Value;
            _fromPhone= configuration.GetSection("SMSService").GetSection("FromPhone").Value;
            apiBaseUrl = configuration.GetSection("TEMPLATEBYTYPR_API_PATH").Value;
            if (_httpClient.BaseAddress == null)
                _httpClient.BaseAddress = new Uri(apiBaseUrl!);
        }
        #region SendNotification
        public async Task<ApiResponseModel> SendNotification(SmsNotification sMSNotification)
        {
            try
            {
                NFType? nFType = (NFType)sMSNotification.NOTIFICATIONTYPE;
                if (nFType != NFType.SMS)
                    throw new InvalidDataException("Notification Type is not a valid type");

                _notificationLog.WriteLogMessage("Checking Phone Number  "+sMSNotification.PHONE);
                ApiResponseModel? apiResponseModel;
                if (sMSNotification.PHONE == null && sMSNotification.PHONE == "")
                    throw new InvalidDataException("Phone Number should not be null");

                #region Calling Get Template API
                //Calling Get Template API
                string endpoint = apiBaseUrl + MethodsName.GetTemplate + "?Type=" + nFType + "&&NotificationId=" + Convert.ToInt32(sMSNotification.TEMPLATENO);
                _notificationLog.WriteLogMessage("Get Template API calling  Endpoint: " + endpoint);
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                using (var Response = await _httpClient.GetAsync(endpoint))
                {
                    var result = await Response.Content.ReadAsStringAsync();
                    apiResponseModel = JsonConvert.DeserializeObject<ApiResponseModel>(result);
                }
                var data = JsonConvert.DeserializeObject<ResponseModel<NotificationParams>>(apiResponseModel!.MsgBdy!.ToString()!);
                
                //If Template exsits
                if (data!.Data == null)
                    throw new InvalidDataException("Template is not available");

                #endregion End API Call

                //Sending SMS using Twilio
                TwilioClient.Init(_accountSID, _authToken);
                var username = sMSNotification.NAME;
                var message = MessageResource.Create(from: new Twilio.Types.PhoneNumber(_fromPhone), 
                    body: String.Format(data.Data.BodyMessage!, username), to: new Twilio.Types.PhoneNumber("+91" + sMSNotification.PHONE));
                _notificationLog.WriteLogMessage("MSG Successfully sent  Ref Id: "+message);
                //END

                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Status = "Success",
                        Message = "SMS Notification Successfully Sent"
                    },
                    MsgBdy = new ResponseModel<string> { Data = message.Sid },
                };
            }
            catch (Exception e)
            {
                _notificationLog.WriteLogMessage("------------------Error------------------\n  "+e.ToString());
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError,
                        Status = "Failed",
                        Message = e.Message
                    }
                };
            }
            
        }
        #endregion 
    }
}
