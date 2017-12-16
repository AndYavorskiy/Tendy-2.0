using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.Common.Utils
{
    public class ErrorInfo
    {
        public string Code { get; private set; }
        public string Message { get; private set; }

        public ErrorInfo(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
