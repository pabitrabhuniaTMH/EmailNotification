using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationEntityModels.Models;
using NotificationServices.IRepository;
using NotificationSystem.Controllers;
using EmailNotificationServices.ServiceHelper;

namespace UnitTestEmailBasedNotification
{
    public class Tests
    {
        #region Test SendNotification To Email

        [Test]
        public void TestSendNotificationToEmail()
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

            //Expected value will be verify with actual value
            var expectedValue = methodAsync();
            Mock<IEmailNotificationServices> mockObj = new Mock<IEmailNotificationServices>();
            mockObj.Setup(x => x.SendNotification(It.IsAny<EmailNotification>())).Returns(expectedValue);
            var SendNotificationToEmailController = new SendNotificationToEmailController(mockObj.Object);
            var actualValue= SendNotificationToEmailController.SendNotificationToEmail(InputValue);

            //Converting actual vaue as  OkObjectResult
            OkObjectResult? okObjectActualValue = actualValue.Result as OkObjectResult;
            ApiResponseModel okObjectexpectedValue = expectedValue.Result as ApiResponseModel;

            //Compare both value Expected and Actual value
            Assert.That(okObjectActualValue.Value, Is.EqualTo(okObjectexpectedValue));
        }

        #endregion

        #region Converting ApiResponseModel
        //Converting for System.Thread.Task type
        private async Task<ApiResponseModel> methodAsync()
        {
            await Task.Delay(10000);
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
    }
}