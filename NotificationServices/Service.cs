using Microsoft.Extensions.DependencyInjection;
using NotificationServices.IRepository;
using NotificationServices.Repository;
using System.Diagnostics.CodeAnalysis;

namespace NotificationServices
{
    public static class Service
    {
        public static IServiceCollection ConfigNotificationService(this IServiceCollection services)
        {
            services.AddScoped<IEmailNotificationServices,EmailNotificationService>();
            return services;
        }
    }
}
