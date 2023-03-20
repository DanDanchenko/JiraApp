using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.Infrastructure;

namespace ToDoCosmos.Infrastructure.Authentication
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid CurrentUserId
        {
            get
            {
                var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Guid.Parse(id);
            }
        }
    }
}
