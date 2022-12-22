using Microsoft.Extensions.Configuration;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;
using OTPServices.ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotificationServices.Repository
{
    public class EmailNotificationServices : IEmailNotificationServices
    {
        public readonly IConfiguration _configuration;
        public readonly string? _sendEmail;
        public readonly string? _sendPassword;
        private readonly NotificationLog _notificationLog;
        private readonly long _timeStamp;
        public EmailNotificationServices(IConfiguration configuration)
        {
            _timeStamp = TimeStamp.GetTimeStamp();
            _notificationLog = new NotificationLog(_timeStamp);
            _sendEmail = configuration.GetSection("MailInfo").GetSection("Email").Value;
            _sendPassword = configuration.GetSection("MailInfo").GetSection("Password").Value;
        }
        public ApiResponseModel SendNotification(EmailNotification emailNotification)
        {
            try
            {
                _notificationLog.WriteLogMessage("Check Email if valid");
                if (!Regex.IsMatch(emailNotification.NotifyTo.EMAIL, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    throw new Exception(emailNotification.NotifyTo.EMAIL+" Is not a valid email");
                _notificationLog.WriteLogMessage(emailNotification.NotifyTo.EMAIL+" this is a valid Email");
                MailMessage mail = new MailMessage();
                mail.To.Add(emailNotification.NotifyTo.EMAIL);
                mail.From = new MailAddress(_sendEmail);            
                mail.Subject = emailNotification.EmailTemplate.EMAILSUBJECT;
                mail.Body = emailNotification.EmailTemplate.EMAILBODY;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(_sendEmail, _sendPassword);   
                smtp.EnableSsl = true;
                _notificationLog.WriteLogMessage("Email Sending...");
                smtp.Send(mail);
                _notificationLog.WriteLogMessage("Email successfully sent...");
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
