using Microsoft.Extensions.DependencyInjection;
using NotificationEntityModels.IRepository;
using NotificationTemplateServices.IRepository;
using NotificationTemplateServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationTemplateServices
{
    public static class Service
    {
        public static IServiceCollection ConfigNotificationTemplateService(this IServiceCollection service)
        {
            service.AddScoped<IEmailNotificationService, EmailNotificationService>();
            return service;
        }
    }
}
