using Microsoft.Extensions.DependencyInjection;
using SMSNotificationServices.IRepository;
using SMSNotificationServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSNotificationServices
{
    public static class Service
    {
        public static IServiceCollection ConfigSMSNotificationService(this IServiceCollection service)
        {
            service.AddScoped<ISMSNotificationService,SMSNotificationService>();
            return service;
        }
    }
}
