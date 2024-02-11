using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.Response
{
    public class ResponseT<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public ResponseT(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public ResponseT(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public ResponseT(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            ValidationErrors = errors;
            Data = data;
        }

        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}


