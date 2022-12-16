using Microsoft.Extensions.DependencyInjection;
using NotificationServices.IRepository;
using NotificationServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationServices
{
    public static class Service
    {
        public static IServiceCollection ConfigNotificationService(this IServiceCollection services)
        {
            services.AddScoped<IEmailNotificationServices,EmailNotificationServices>();
            return services;
        }
    }
}
