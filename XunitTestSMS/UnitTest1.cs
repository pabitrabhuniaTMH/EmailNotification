
using Microsoft.Extensions.DependencyInjection;
using NotificationServices;
using NotificationTemplateServices;
using SMSNotificationServices;

namespace XunitTestSMS
{
    public class UnitTest1
    {
        [Fact]
        public void IocContainer_GetService_RequestHandler()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigSMSNotificationService();
            serviceCollection.ConfigNotificationService();
            serviceCollection.ConfigNotificationTemplateService();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(serviceProvider);
        }
    }
}