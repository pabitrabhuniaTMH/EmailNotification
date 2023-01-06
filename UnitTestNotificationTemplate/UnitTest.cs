using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationServices;
using NotificationTemplate.Controllers;
using NotificationTemplateDBAccess;
using NotificationTemplateDBAccess.Repository;
using NotificationTemplateServices;
using NotificationTemplateServices.IRepository;
using NotificationTemplateServices.Repository;
using NUnit.Framework;
using SMSNotificationServices.ServiceHelper;

namespace UnitTestNotificationTemplate
{
    public class Tests
    {
        private readonly Mock<IEmailNotificationService> _mockObjEmailNotification;
        private readonly Mock<ITemplateServices> _mockObjTemplateServices;
        private readonly Mock<IEmailNotification> _mockObjTemplate;
        private readonly Mock<ITemplate> _mockObjGetTemplate;
        public Tests()
        {
            //Creating Fake mock Object for constructor parameter
            _mockObjEmailNotification= new Mock<IEmailNotificationService>();
            _mockObjTemplateServices= new Mock<ITemplateServices>();
            _mockObjTemplate = new Mock<IEmailNotification>();
            _mockObjGetTemplate= new Mock<ITemplate>();
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
            OkObjectResult? okObjectActualValue = actualValue as OkObjectResult;

            //Compare both value Expected and Actual value
            Assert.That(okObjectActualValue!.Value, Is.EqualTo(expectedValue));           
        }
        #endregion
        [Test]
        public void TestSaveNotificationTemplateServices()
        {
            var inputValue= new EmailNotificationTemplate
            {
                NotificationType = "E",
                Type = "Customize",
                Subject = "Welcome",
                BodyMassage = "Hi {0}, Welcome to INT",
                TemplateValidUpto = Convert.ToDateTime("2023-05-16T05:50:06.7199222"),
                RequestDevice = "40-8D-5C-36-32-32",
                Requestion = 0
            };
            var expectedValue = new BaseResponseModel { ID = TimeStamp.GetTimeStamp(), Message = "Data Has Been Successfully saved", Status ="Success", StatusCode = 200 };
            _mockObjTemplate.Setup(x => x.SeveNotification(It.IsAny<EmailNotificationTemplate>())).Returns(-1);
            var emailNotificationService = new EmailNotificationServices(_mockObjTemplate.Object);
            var actualValue = emailNotificationService.SaveNotificationTemplate(inputValue);
            var responseObject=new ResponseModel<object> { Data= actualValue.MsgHdr };
            var responseData = responseObject.Data;
            ResponseModel<BaseResponseModel>? responseModel = responseData as ResponseModel<BaseResponseModel>;
            BaseResponseModel? response = responseModel!.Data;
            expectedValue.ID = response!.ID;
            Assert.That(response.ID, Is.EqualTo(expectedValue.ID));
            Assert.That(response.StatusCode, Is.EqualTo(expectedValue.StatusCode));
            Assert.That(response.Status, Is.EqualTo(expectedValue.Status));
            Assert.That(response.Message, Is.EqualTo(expectedValue.Message));
        }

        [Test]
        public void TestSaveNotificationTemplateServicesNullCheck()
        {
            var inputValue = new EmailNotificationTemplate
            {
                NotificationType = "EMAIL",
                Type = "Customize",
                Subject = "Welcome",
                BodyMassage = "Hi {0}, Welcome to INT",
                TemplateValidUpto = Convert.ToDateTime("2023-05-16T05:50:06.7199222"),
                RequestDevice = "40-8D-5C-36-32-32",
                Requestion = 0
            };
            var expectedValue = new BaseResponseModel { ID = TimeStamp.GetTimeStamp(), Message = "Notification Type is invalid", Status = "Failed", StatusCode = 422 };
            _mockObjTemplate.Setup(x => x.SeveNotification(It.IsAny<EmailNotificationTemplate>())).Returns(-1);
            var emailNotificationService = new EmailNotificationServices(_mockObjTemplate.Object);
            var actualValue = emailNotificationService.SaveNotificationTemplate(inputValue);
            var responseObject = new ResponseModel<object> { Data = actualValue.MsgHdr };
            var responseData = responseObject.Data;
            ResponseModel<BaseResponseModel>? responseModel = responseData as ResponseModel<BaseResponseModel>;
            BaseResponseModel? response = responseModel!.Data;
            expectedValue.ID = response!.ID;
            Assert.That(response.ID, Is.EqualTo(expectedValue.ID));
            Assert.That(response.StatusCode, Is.EqualTo(expectedValue.StatusCode));
            Assert.That(response.Status, Is.EqualTo(expectedValue.Status));
            Assert.That(response.Message, Is.EqualTo(expectedValue.Message));
        }

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
            var exepectedPrmsValue = new NotificationParams
            {
                ID = 23,
                NotificationType ="EMAIL",
                Type ="string",
                TemplateValidUpto = "12/21/2022 10:31:15",
                Subject = "Welcome Message !",
                BodyMessage = "Hi,{0} Welcome to INT !",
                RequestDevice ="string",
                Requestion ="0"
            };
            _mockObjTemplateServices.Setup(x => x.GetTemplateByType(It.IsAny<string>(), It.IsAny<int>())).Returns(JsonConvert.DeserializeObject<ApiResponseModel>(expectedValue!));
            var notificationTemplateController = new NotificationTemplateController(_mockObjEmailNotification.Object, _mockObjTemplateServices.Object);
            var actualValue = notificationTemplateController.GetNotificationTemplate("E",23);
            
             //Converting actual value as  OkObjectResult
             OkObjectResult? okObjectActualValue = actualValue as OkObjectResult;
            var valueForActual = JsonConvert.SerializeObject(okObjectActualValue!.Value);
            ApiResponseModel? apiResponseModel = JsonConvert.DeserializeObject<ApiResponseModel>(expectedValue);
            var response = apiResponseModel!.MsgBdy!.ToString();
            var a = JsonConvert.DeserializeObject<ResponseModel<NotificationParams>>(response!);
           
            NotificationParams? actualParamsValue = a!.Data;
            var valueForexpected = JsonConvert.SerializeObject(apiResponseModel);
            //Compare both value Expected and Actual value
            Assert.That(valueForActual, Is.EqualTo(valueForexpected));
            Assert.That(exepectedPrmsValue.ID, Is.EqualTo(actualParamsValue!.ID));
            Assert.That(exepectedPrmsValue.NotificationType, Is.EqualTo(actualParamsValue.NotificationType));
            Assert.That(exepectedPrmsValue.Type, Is.EqualTo(actualParamsValue.Type));
            Assert.That(exepectedPrmsValue.TemplateValidUpto, Is.EqualTo(actualParamsValue.TemplateValidUpto));
            Assert.That(exepectedPrmsValue.Subject, Is.EqualTo(actualParamsValue.Subject));
            Assert.That(exepectedPrmsValue.BodyMessage, Is.EqualTo(actualParamsValue.BodyMessage));
            Assert.That(exepectedPrmsValue.RequestDevice, Is.EqualTo(actualParamsValue.RequestDevice));
            Assert.That(exepectedPrmsValue.Requestion, Is.EqualTo(actualParamsValue.Requestion));
        }
        #endregion

        [Test]
        public void TestGetTemplateServices()
        {
            
            IEnumerable<NotificationParams> expectedValue = new List<NotificationParams>
            {
                new NotificationParams
                {
                    ID=23,
                    NotificationType="EMAIL",
                    Type="string",
                    TemplateValidUpto="21-12-22",
                    Subject="Welcome Message !",
                    BodyMessage="Hi,{0} Welcome to INT !",
                    RequestDevice="string",
                    Requestion="0",
                }
            };
            _mockObjGetTemplate.Setup(x => x.GetTemplateByType("EMAIL",23)).Returns(expectedValue);
            var template = new TemplateServices(_mockObjGetTemplate.Object);
            var actualValue = template.GetTemplateByType("EMAIL",23);
            var responseObject = new ResponseModel<object> { Data = actualValue.MsgBdy };
            var responseData = responseObject.Data;
            ResponseModel<NotificationParams>? responseModel = responseData as ResponseModel<NotificationParams>;
            var response = responseModel!.Data;
            Assert.That(response, Is.EqualTo(expectedValue.FirstOrDefault()));


        }

        [Test]
        public void TestGetTemplateServicesNullCheck()
        {

            IEnumerable<NotificationParams> expectedValue = new List<NotificationParams>
            {
                new NotificationParams
                {
                    ID=23,
                    NotificationType="EMAIL",
                    Type="string",
                    TemplateValidUpto="21-12-22",
                    Subject="Welcome Message !",
                    BodyMessage="Hi,{0} Welcome to INT !",
                    RequestDevice="string",
                    Requestion="0",
                }
            };
            _mockObjGetTemplate.Setup(x => x.GetTemplateByType("", 23)).Returns(expectedValue);
            var template = new TemplateServices(_mockObjGetTemplate.Object);
            var actualValue = template.GetTemplateByType("", 23);
            var responseObject = new ResponseModel<object> { Data = actualValue.MsgBdy };
            var responseData = responseObject.Data;
            Assert.Null(responseData);

        }

        [Test]
        public void TestTemplateDBAccess()
        {
            var inputValue = new EmailNotificationTemplate
            {
                NotificationType = "EMAIL",
                Type = "Customize",
                Subject = "Welcome",
                BodyMassage = "Hi {0}, Welcome to INT",
                TemplateValidUpto = Convert.ToDateTime("2023-05-16T05:50:06.7199222"),
                RequestDevice = "40-8D-5C-36-32-32",
                Requestion = 0
            };
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"ConnectionStrings:DefaultConnection", "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.0.4.60)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl3pdb)));User Id=EASYCCINT;Password=P4ssw0rd;"}
            //...populate as needed for the test
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var a = new Template(configuration);
            var b = a.GetTemplateByType("EMAIL",23);
            var emailNotification = new NotificationTemplateDBAccess.Repository.EmailNotification(configuration);
            var resultSaveNotification = emailNotification.SeveNotification(inputValue);
            Assert.NotZero(resultSaveNotification);
            Assert.NotNull(b);

        }

        [Test]
        public void TestConfigNotificationService()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigNotificationService();
            serviceCollection.ConfigNotificationTemplateService();
            serviceCollection.ConfigNotificationTemplateDBAccess();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.That(serviceProvider,Is.Not.Null);
        }
    }
}