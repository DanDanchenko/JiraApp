using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCosmos.Infrastructure.Authentication
{
    public interface IAuthenticationService
    {
        Task<User> CreateUserAsync(CreateUserDTO userDto);
        Task<User?> AuthenticateUserAsync(AuthenticationUserDTO userDto);
    }
}
