using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ToDoCosmos.BusinessLogic.Exceptions
{
    public class JiraNotFoundException : JiraException
    {
        public JiraNotFoundException() : base("ToDoItem with given Id is not found", HttpStatusCode.NotFound)
        {

        }
    }
}
