using Microsoft.Extensions.DependencyInjection;
using NotificationTemplateServices.IRepository;
using NotificationTemplateServices.Repository;
using System.Diagnostics.CodeAnalysis;

namespace NotificationTemplateServices
{
    public static class Service
    {
        public static IServiceCollection ConfigNotificationTemplateService(this IServiceCollection service)
        {
            service.AddScoped<IEmailNotificationService, EmailNotificationServices>();
            service.AddScoped<ITemplateServices, TemplateServices>();
            return service;
        }
    }
}
