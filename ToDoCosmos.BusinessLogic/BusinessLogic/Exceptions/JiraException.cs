using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ToDoCosmos.BusinessLogic.Exceptions
{
    public class JiraException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public JiraException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
