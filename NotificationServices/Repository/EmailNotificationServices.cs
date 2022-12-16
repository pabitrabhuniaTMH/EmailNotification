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
        public readonly string _sendEmail;
        public readonly string _sendPassword;
        public EmailNotificationServices(IConfiguration configuration)
        {
            _sendEmail = configuration.GetSection("MailInfo").GetSection("Email").Value;
            _sendPassword = configuration.GetSection("MailInfo").GetSection("Password").Value;
        }
        public ApiResponseModel SendNotification(EmailNotification emailNotification)
        {
            try
            {
                if (!Regex.IsMatch(emailNotification.NotifyTo.EMAIL, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    throw new Exception(emailNotification.NotifyTo.EMAIL+" Is not a valid email");
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
                smtp.Send(mail);
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
