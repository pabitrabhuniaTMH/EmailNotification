using Microsoft.Extensions.DependencyInjection;
using NotificationEntityModels.IRepository;
using NotificationTemplateDBAccess.Repository;

namespace NotificationTemplateDBAccess
{
    public static class Service
    {
        public static IServiceCollection ConfigNotificationTemplateDBAccess(this IServiceCollection service)
        {
            service.AddScoped<IEmailNotification,EmailNotification>();
            service.AddScoped<ITemplate, Template>();
            return service;
        }
    }
}
