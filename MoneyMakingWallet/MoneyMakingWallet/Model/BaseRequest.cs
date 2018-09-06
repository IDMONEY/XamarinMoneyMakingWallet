#region Libraries
using System.Collections.Generic; 
#endregion

namespace IDMONEY.IO.Model
{
    public abstract class BaseRequest
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
