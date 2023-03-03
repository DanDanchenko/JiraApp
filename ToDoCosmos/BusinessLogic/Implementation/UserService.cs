using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.BusinessLogic.Interfaces;

namespace ToDoCosmos.BusinessLogic.Implementation
{
    public class UserService : IUserService
    {
        public static readonly Guid UserId = new("8360e917-5e1d-44c7-a449-e115b69280bb");

        public Guid CurrentUserId => UserId;
    }


}
