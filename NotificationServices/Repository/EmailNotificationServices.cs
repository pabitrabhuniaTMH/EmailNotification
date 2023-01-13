using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;
using SMSNotificationServices.ServiceHelper;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace NotificationServices.Repository
{
    [ExcludeFromCodeCoverage]
    public class EmailNotificationService : IEmailNotificationServices
    {
        public readonly IConfiguration? _configuration;
        public readonly string? _sendEmail;
        public readonly string? _sendPassword;
        private readonly NotificationLog _notificationLog;
        private readonly string? apiBaseUrl;
        private static readonly HttpClient _httpClient = new();
        
        public EmailNotificationService(IConfiguration configuration)
        {
            _notificationLog = new NotificationLog(TimeStamp.GetTimeStamp());
            apiBaseUrl = configuration.GetSection("TEMPLATEBYTYPR_API_PATH").Value;
            if (_httpClient.BaseAddress==null)
                _httpClient.BaseAddress = new Uri(apiBaseUrl!);
            _sendEmail = configuration.GetSection("MailInfo").GetSection("Email").Value;
            _sendPassword = configuration.GetSection("MailInfo").GetSection("Password").Value;
        }
        #region send notification to email
        public async Task<ApiResponseModel> SendNotification(EmailNotification emailNotification)
        {
            try
            {
                NFType? nFType =(NFType)emailNotification.NotificationType!;
                if (nFType != NFType.EMAIL)
                    throw new InvalidDataException("Notification Type is not a valid type");
                ApiResponseModel? apiResponseModel;
                _notificationLog.WriteLogMessage("Check Email if valid");

                //check valid email
                if (!Regex.IsMatch(emailNotification.NotifyTo!.EMAIL!, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    throw new InvalidDataException(emailNotification.NotifyTo.EMAIL + " Is not a valid email");

                //Called Get Template API
                string endpoint = apiBaseUrl + MethodsName.GetTemplate + "?Type="+ nFType+"&&NotificationId="+Convert.ToInt32(emailNotification.NotificationTemplateId);
                _notificationLog.WriteLogMessage("Get Template API calling  Endpoint: "+endpoint);
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
                var username = emailNotification.NotifyTo.NAME;
                #region Email sending
                MailMessage mail = new();
                mail.To.Add(emailNotification.NotifyTo.EMAIL!);
                mail.From = new MailAddress(_sendEmail!);
                mail.Subject =data.Data.Subject;
                mail.Body = String.Format(data.Data.BodyMessage!,username);
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new()) //SMTP request
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
                #endregion

                return new ApiResponseModel
                {
                    MsgHdr = new ResponseModel<BaseResponseModel> {
                        Data=new BaseResponseModel { 
                            ID=TimeStamp.GetTimeStamp(),
                            Status="Success",
                            StatusCode=HttpStatusCode.OK,
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
                            StatusCode = HttpStatusCode.InternalServerError,
                            Message = ex.ToString()
                        }
                    }
                };
            }
            
        }
        #endregion

    }

}
