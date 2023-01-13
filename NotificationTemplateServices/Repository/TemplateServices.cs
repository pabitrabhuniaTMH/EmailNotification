using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;
using SMSNotificationServices.ServiceHelper;

namespace NotificationTemplateServices.Repository
{
    public class TemplateServices : ITemplateServices
    {
        private readonly ITemplate _template;
        public TemplateServices(ITemplate template)
        {
            _template=template;
        }
        #region Get Template

        public ApiResponseModel GetTemplateByType(string type,int NotificationId)
        {
            try
            {
                if (type == null || type == "")
                    throw new InvalidDataException("Type Should Not Be Bull");
                var result=_template.GetTemplateByType(type!, NotificationId);
                if (result!=null)
                {
                    return new ApiResponseModel
                    {
                        MsgHdr = new BaseResponseModel
                        {
                            ID = TimeStamp.GetTimeStamp(),
                            Status = "Success",
                            StatusCode = System.Net.HttpStatusCode.OK
                        },
                        MsgBdy = new ResponseModel<NotificationParams>
                        {
                            Data = result.FirstOrDefault()
                        }
                    };
                }
                throw new InvalidDataException();
            }
            catch(InvalidDataException e)
            {
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        Status = "Failed",
                        StatusCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = e.Message
                    }
                };
            }
        }
        #endregion
    }
}
