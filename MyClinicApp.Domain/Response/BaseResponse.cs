using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.Domain.Enum;

namespace MyClinicApp.Domain.Response
{
    public interface IBaseResponse<T>
    {
        string Description { get; set; }
        StatusCode StatusCode { get; set; }
        T Data { get; set; }
    }

    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
