using EmailNotificationServices.ServiceHelper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;
using OTPServices.ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Twilio.Http;

namespace NotificationServices.Repository
{
    public class EmailNotificationService : IEmailNotificationServices
    {
        public readonly IConfiguration _configuration;
        public readonly string? _sendEmail;
        public readonly string? _sendPassword;
        private readonly NotificationLog _notificationLog;
        private readonly long _timeStamp;
        private static string apiBaseUrl = String.Empty;
        private static readonly System.Net.Http.HttpClient _httpClient = new();
        public EmailNotificationService(IConfiguration configuration)
        {
            _timeStamp = TimeStamp.GetTimeStamp();
            _notificationLog = new NotificationLog(_timeStamp);
            apiBaseUrl = configuration.GetSection("TEMPLATEBYTYPR_API_PATH").Value;
            if (_httpClient.BaseAddress==null)
                _httpClient.BaseAddress = new Uri(apiBaseUrl);
            _sendEmail = configuration.GetSection("MailInfo").GetSection("Email").Value;
            _sendPassword = configuration.GetSection("MailInfo").GetSection("Password").Value;
        }
        public async Task<ApiResponseModel> SendNotification(EmailNotification emailNotification)
        {
            try
            {
                NFType? nFType =(NFType)emailNotification.NotificationType;
                if (nFType != NFType.EMAIL)
                    throw new Exception("Notification Type is not a valid type");
                ApiResponseModel? apiResponseModel = new ApiResponseModel();
                _notificationLog.WriteLogMessage("Check Email if valid");
                if (!Regex.IsMatch(emailNotification.NotifyTo.EMAIL, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    throw new Exception(emailNotification.NotifyTo.EMAIL + " Is not a valid email");
                _notificationLog.WriteLogMessage(emailNotification.NotifyTo.EMAIL + " this is a valid Email");
                string endpoint = apiBaseUrl + MethodsName.GetTemplate + "?Type="+ nFType+"&&NotificationId="+Convert.ToInt32(emailNotification.NotificationTemplateId);
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                using (var Response = await _httpClient.GetAsync(endpoint))
                {
                    var result = await Response.Content.ReadAsStringAsync();
                    apiResponseModel = JsonConvert.DeserializeObject<ApiResponseModel>(result);
                }
               // NotificationParams prm = new NotificationParams();
                var data = JsonConvert.DeserializeObject<ResponseModel<NotificationParams>>(apiResponseModel.MsgBdy.ToString());
                if (data.Data == null)
                    throw new Exception("Template is not available");
                var username = emailNotification.NotifyTo.NAME;
                MailMessage mail = new MailMessage();
                mail.To.Add(emailNotification.NotifyTo.EMAIL);
                mail.From = new MailAddress(_sendEmail);
                mail.Subject =data.Data.Subject;
                mail.Body = String.Format(data.Data.BodyMessage,username);
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient()) //SMTP request
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(_sendEmail, _sendPassword);
                    smtp.EnableSsl = true;
                    _notificationLog.WriteLogMessage("Email Sending...");
                    smtp.Send(mail);
                    _notificationLog.WriteLogMessage("Email successfully sent...");
                }
                    
                
                return new ApiResponseModel
                {
                    MsgHdr = new ResponseModel<BaseResponseModel> {
                        Data=new BaseResponseModel { 
                            ID=TimeStamp.GetTimeStamp(),
                            Status="Success",
                            StatusCode=200,
                            Message="Email Notification successfullly sent"
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                _notificationLog.WriteLogMessage(ex.ToString());
                return new ApiResponseModel
                {
                    MsgHdr = new ResponseModel<BaseResponseModel>
                    {
                        Data = new BaseResponseModel
                        {
                            ID = TimeStamp.GetTimeStamp(),
                            Status = "Failed",
                            StatusCode = 400,
                            Message = ex.ToString()
                        }
                    }
                };
            }
            
        }

    }
}
