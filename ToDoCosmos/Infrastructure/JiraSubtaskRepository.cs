using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.Domain;

namespace ToDoCosmos.Infrastructure
{
    public class JiraSubtaskRepository : ISubtaskRepository
    {

        private readonly JiraContext _context;
        private readonly IUserService _userService;

        public JiraSubtaskRepository (JiraContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


    }
}
