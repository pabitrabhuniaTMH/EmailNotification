using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NotificationEntityModels.Models;
using SMSBasedNotification.Controllers;
using SMSNotificationServices;
using SMSNotificationServices.IRepository;
using SMSNotificationServices.Repository;
using SMSNotificationServices.ServiceHelper;

namespace UnitTestSMSBaseNotification
{
    public class Tests
    {
        #region Test SendNotification To SMS
        [Test]
        public void TestSendNotificationToSMS()
        {
            Mock<ISmsNotificationService> mockObject = new Mock<ISmsNotificationService>();
            //Input Value
            var InputValue = new SmsNotification
            {
                ID = 321654,
                NAME = "Pabitra Bhunia",
                NOTIFICATIONTYPE = 'S',
                PHONE = "7718354967",
                TEMPLATENO = 22
            };
            var expectedValue = ConvertToTask();
            mockObject.Setup(x => x.SendNotification(It.IsAny<SmsNotification>())).Returns(expectedValue);

            var sendNotificationToSMSController = new SendNotificationToSmsController(mockObject.Object);
            var actualValue = sendNotificationToSMSController.SendNotificationToSMS(InputValue);

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
                MsgHdr = new BaseResponseModel
                {
                    ID = TimeStamp.GetTimeStamp(),
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Status = "Success",
                    Message = "SMS Notification Successfully Sent"
                },
                MsgBdy = new ResponseModel<string> { Data = "hfjhskfjs7sdsd9sdsd9bd79s" },
            };
        }

        [Test]
        public void TestSendSmsNotificationService()
        {
            var InputValue = new SmsNotification
            {
                ID = 321654,
                NAME = "Pabitra Bhunia",
                NOTIFICATIONTYPE = 'S',
                PHONE = "7718354967",
                TEMPLATENO = 22
            };
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"TEMPLATEBYTYPR_API_PATH", "https://localhost:7188/api/v0.0.1/"},
                {"SMSService:AccountSID", "AC1a0697ca90611de722b2782f85f93528"},
                {"SMSService:AuthToken", "129c818a075cf5197f27d6d927308808"},
                {"SMSService:FromPhone", "+18455818346"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            var smsNotificationService = new SmsNotificationService(configuration);
            var result = smsNotificationService.SendNotification(InputValue);
            InputValue.NOTIFICATIONTYPE = 'Y';
            var resultExeception = smsNotificationService.SendNotification(InputValue);
            Assert.Multiple(() =>
            {
                Assert.That(resultExeception, Is.Not.Null);
                Assert.That(result, Is.Not.Null);
            });
        }
        #endregion

        [Test]
        public void TestConfigSMSNotificationService()
        {
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigSMSNotificationService();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.That(serviceProvider, Is.Not.Null);
        }
    }
}