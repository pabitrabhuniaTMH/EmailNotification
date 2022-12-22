﻿using NotificationEntityModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationTemplateServices.IRepository
{
    public interface IEmailNotificationService
    {
        public ApiResponseModel SaveNotificationTemplate(EmailNotificationTemplate emailNotificationTemplate);
    }
}