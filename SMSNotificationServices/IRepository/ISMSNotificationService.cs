using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationEntityModels.Models;
namespace SMSNotificationServices.IRepository
{
    public interface ISMSNotificationService
    {
        public ApiResponseModel SendNotification(SMSNotification sMSNotification);
    }
}
