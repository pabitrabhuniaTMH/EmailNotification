using NotificationEntityModels.IRepository;
using NotificationEntityModels.Models;
using NotificationTemplateServices.IRepository;
using OTPServices.ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var result=_template.GetTemplateByType(type, NotificationId);
                if (result!=null)
                {
                    return new ApiResponseModel
                    {
                        MsgHdr = new BaseResponseModel
                        {
                            ID = TimeStamp.GetTimeStamp(),
                            Status = "Success",
                            StatusCode = 200
                        },
                        MsgBdy = new ResponseModel<NotificationParams>
                        {
                            Data = result.FirstOrDefault()
                        }
                    };
                }
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        Status = "Failed",
                        StatusCode = 422,
                        Message = "There is a internal error"
                    }
                };
            }
            catch(Exception e)
            {
                return new ApiResponseModel
                {
                    MsgHdr = new BaseResponseModel
                    {
                        ID = TimeStamp.GetTimeStamp(),
                        Status = "Failed",
                        StatusCode = 422,
                        Message = e.Message
                    }
                };
            }
        }
        #endregion
    }
}
