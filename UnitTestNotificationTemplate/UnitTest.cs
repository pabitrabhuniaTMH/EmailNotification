using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NotificationEntityModels.Models;
using NotificationTemplate.Controllers;
using NotificationTemplateServices.IRepository;
using NUnit.Framework;
using OTPServices.ServiceHelper;

namespace UnitTestNotificationTemplate
{
    public class Tests
    {
        private readonly Mock<IEmailNotificationService> _mockObjEmailNotification;
        private readonly Mock<ITemplateServices> _mockObjTemplateServices;
        public Tests()
        {
            //Creating Fake mock Object for constructor parameter
            _mockObjEmailNotification= new Mock<IEmailNotificationService>();
            _mockObjTemplateServices= new Mock<ITemplateServices>();
        }

        #region Test SaveNotification Template
        [Test]
        public void TestSaveNotificationTemplate()
        {
            //Expected value will be verify with actual value
            var expectedValue = new ApiResponseModel
            {
                MsgHdr = new ResponseModel<BaseResponseModel>
                {
                    Data = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        StatusCode = 200,
                        Status = "Success",
                        Message = "Data Has Been Successfully saved"
                    }
                }
            };
            _mockObjEmailNotification.Setup(x => x.SaveNotificationTemplate(It.IsAny<EmailNotificationTemplate>())).Returns(expectedValue);
            var notificationTemplateController =new NotificationTemplateController(_mockObjEmailNotification.Object, _mockObjTemplateServices.Object);

            //It will return actual value
            var actualValue = notificationTemplateController.SaveEmailNotificationTemplate(
                    new EmailNotificationTemplate
                    {
                        NotificationType = "E",
                        Type = "Customize",
                        Subject = "Welcome",
                        BodyMassage = "Hi {0}, Welcome to INT",
                        TemplateValidUpto = Convert.ToDateTime("2023-05-16T05:50:06.7199222"),
                        RequestDevice= "40-8D-5C-36-32-32",
                        Requestion=0
                    });

            //Converting actual vaue as  OkObjectResult
            OkObjectResult okObjectActualValue = actualValue as OkObjectResult;

            //Compare both value Expected and Actual value
            Assert.That(okObjectActualValue.Value, Is.EqualTo(expectedValue));           
        }
        #endregion

        #region Get Notification Template
        [Test]
        public void GetNotificationTemplate()
        {
            //Expected value will be verify with actual value
            var expectedValue = "{\r\n \"msgHdr\": {\r\n\"statusCode\": 200,\r\n\"status\": \"Success\",\r\n\"message\": null," +
                "\r\n\"id\": 1672227322\r\n},\r\n  \"msgBdy\": {\r\n\"data\": {\r\n\"id\": 23,\r\n\"notificationType\":" +
                " \"EMAIL\",\r\n\"type\": \"string\",\r\n\"templateValidUpto\": \"12/21/2022 10:31:15\",\r\n\"subject\": " +
                "\"Welcome Message !\",\r\n \"bodyMessage\": \"Hi,{0} Welcome to INT !\",\r\n\"requestDevice\": \"string\"," +
                "\r\n\"requestion\": \"0\",\r\n\"task\": null\r\n}\r\n}\r\n}";
            _mockObjTemplateServices.Setup(x => x.GetTemplateByType(It.IsAny<string>(), It.IsAny<int>())).Returns(JsonConvert.DeserializeObject<ApiResponseModel>(expectedValue));
            var notificationTemplateController = new NotificationTemplateController(_mockObjEmailNotification.Object, _mockObjTemplateServices.Object);
            var actualValue = notificationTemplateController.GetNotificationTemplate("E",23);
           
            //Converting actual value as  OkObjectResult
            OkObjectResult okObjectActualValue = actualValue as OkObjectResult;
            var valueForActual = JsonConvert.SerializeObject(okObjectActualValue.Value);
            ApiResponseModel apiResponseModel = JsonConvert.DeserializeObject<ApiResponseModel>(expectedValue);
            var valueForexpected = JsonConvert.SerializeObject(apiResponseModel);
            //Compare both value Expected and Actual value
            Assert.That(valueForActual, Is.EqualTo(valueForexpected));
        }
        #endregion
    }
}