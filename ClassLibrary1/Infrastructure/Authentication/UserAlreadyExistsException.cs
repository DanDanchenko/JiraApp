using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ToDoCosmos.BusinessLogic.Exceptions;

namespace ToDoCosmos.Infrastructure.Authentication
{
    public class UserAlreadyExistsException : JiraException
    {
        public UserAlreadyExistsException() : base("User with given name already exists", HttpStatusCode.BadRequest)
        {

        }
    }
}
