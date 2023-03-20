using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ToDoCosmos.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JiraContext _context;

        public AuthenticationService(JiraContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateUserAsync(AuthenticationUserDTO userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == userDto.Name);
            if (user is null
                || user.Password != userDto.Password)
            {
                return null;
            }

            return new User
            {
                Id = user.Id,
                Name = user.Name,
            };
        }

        public async Task<User> CreateUserAsync(CreateUserDTO userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Name == userDto.Name);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException();
            }

            var user = new Domain.User
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Password = userDto.Password
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new User
            {
                Id = user.Id,
                Name = userDto.Name
            };
        }
    }
}
