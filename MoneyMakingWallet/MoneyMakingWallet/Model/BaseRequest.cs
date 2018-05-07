using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class BaseRequest
    {
        public bool IsSuccessful { get; set; }

        public List<Error> Errors { get; set; }

        public BaseRequest()
        {
            Errors = new List<Error>();
        }
    }

    public class Error
    {
        public Error()
        {

        }

        public string Message { set; get; }
        public string Code { set; get; }
    }
}
