using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NotificationEntityModels.Models;
using NotificationServices;
using NotificationServices.IRepository;
using NotificationSystem.Controllers;
using SMSNotificationServices.ServiceHelper;

namespace UnitTestEmailBasedNotification
{
    public static class Tests
    {
        #region Test SendNotification To Email

        [Test]
        public static void TestSendNotificationToEmail()
        {

            //Input Value
            var InputValue = new EmailNotification
            {
                NotificationTemplateId = "23",
                NotificationType = 'E',
                NotifyTo = new NotifyTo
                {
                    ID = 321654,
                    NAME = "Pabitra Bhunia",
                    EMAIL = "pabitra.bhunia@indusnet.co.in"
                }
            };
            var mockObj = new Mock<IEmailNotificationServices>();
            //Expected value will be verify with actual value
            var expectedValue = ConvertToTask();
            mockObj.Setup(x => x.SendNotification(It.IsAny<EmailNotification>())).Returns(expectedValue);
            var SendNotificationToEmailController = new SendNotificationToEmailController(mockObj.Object);
            var actualValue= SendNotificationToEmailController.SendNotificationToEmail(InputValue);

            //Converting actual vaue as  OkObjectResult
            OkObjectResult? okObjectActualValue = actualValue.Result as OkObjectResult;
            ApiResponseModel okObjectexpectedValue = expectedValue.Result;

            //Compare both value Expected and Actual value
            Assert.That(okObjectActualValue!.Value, Is.EqualTo(okObjectexpectedValue));
        }

        #endregion

        #region Converting ApiResponseModel
        //Converting for System.Thread.Task type
        private static async Task<ApiResponseModel> ConvertToTask()
        {
            await Task.Delay(1000);
            return new ApiResponseModel
            {
                MsgHdr = new ResponseModel<BaseResponseModel>
                {
                    Data = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        Status = "Success",
                        StatusCode = 200,
                        Message = "Email Notification successfullly sent"
                    }
                }
            };
        }
        #endregion

        [Test]
        public static void TestConfigNotificationService()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigNotificationService();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(serviceProvider);
        }
    }
}