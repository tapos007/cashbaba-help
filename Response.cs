using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Response
    {
        bool IsSuccess = false;
        string Message;
        object ResponseData;

        public Response(bool status, string message, object data)
        {
            IsSuccess = status;
            Message = message;
            ResponseData = data;
        }
    }
}
