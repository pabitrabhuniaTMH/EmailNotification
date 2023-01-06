using Microsoft.Extensions.DependencyInjection;
using SMSNotificationServices.IRepository;
using SMSNotificationServices.Repository;
using System.Diagnostics.CodeAnalysis;

namespace SMSNotificationServices
{
    public static class Service
    {
        public static IServiceCollection ConfigSMSNotificationService(this IServiceCollection service)
        {
            service.AddScoped<ISmsNotificationService,SmsNotificationService>();
            return service;
        }
    }
}
