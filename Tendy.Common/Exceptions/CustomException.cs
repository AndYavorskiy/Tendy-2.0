using Tendy.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.Common.Exceptions
{
    public class CustomException : Exception
    {
        public int? StatusCode { get; set; }
        public string ErrorCode { get; set; }

        public CustomException(int? statusCode, ErrorInfo errorInfo)
             : base(errorInfo.Message)
        {
            StatusCode = statusCode;
            ErrorCode = errorInfo.Code;
        }

        public CustomException(int? statusCode, ErrorInfo errorInfo, Exception inner)
            : base(errorInfo.Message, inner)
        {
            StatusCode = statusCode;
            ErrorCode = errorInfo.Code;
        }
    }
}
