using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEntityModels.Models
{
    public class ApiResponseModel
    {
        public object? MsgHdr { get; set; }
        public object? MsgBdy { get; set; }
    }
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
    }
    public class BaseResponseModel : BaseEntity
    {
        public int StatusCode { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
