using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationEntityModels.Models;
using SMSBasedNotification.Controllers;
using SMSNotificationServices.IRepository;
using SMSNotificationServices.ServiceHelper;

namespace UnitTestSMSBaseNotification
{
    public class Tests
    {
        #region Test SendNotification To SMS
        [Test]
        public void TestSendNotificationToSMS()
        {
            Mock<ISMSNotificationService> mockObject = new Mock<ISMSNotificationService>();
            //Input Value
            var InputValue = new SMSNotification
            {
                ID = 321654,
                NAME="Pabitra Bhunia",
                NOTIFICATIONTYPE='S',
                PHONE="7718354967",
                TEMPLATENO=22
            };
            var expectedValue = methodAsync();
            mockObject.Setup(x => x.SendNotification(It.IsAny<SMSNotification>())).Returns(expectedValue);

            var sendNotificationToSMSController = new SendNotificationToSMSController(mockObject.Object);
            var actualValue = sendNotificationToSMSController.SendNotificationToSMS(InputValue);

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
                MsgHdr = new BaseResponseModel
                {
                    ID = TimeStamp.GetTimeStamp(),
                    StatusCode = 200,
                    Status = "Success",
                    Message = "SMS Notification Successfully Sent"
                },
                MsgBdy = new ResponseModel<string> { Data = "hfjhskfjs7sdsd9sdsd9bd79s" },
            };
        }
        #endregion
    }
}