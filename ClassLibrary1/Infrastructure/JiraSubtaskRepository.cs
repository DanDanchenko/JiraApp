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

       public async Task AddAsync(Subtask subtask, Guid userStoryId)
        {
            var userId = _userService.CurrentUserId;

            var assignee = await _context.Users.FirstAsync(x => x.Id.Equals(userId));
            subtask.AssigneeId = assignee.Id;

            subtask.Status = "";

            _context.Stories.FirstOrDefault(x => x.Id.Equals(userStoryId)).Subtasks.Add(subtask);

            await _context.SaveChangesAsync();


        }


      public async Task<IEnumerable<Subtask>> GetAllSubtasksAsync(Guid userStoryId)
        {
            var story = _context.Stories.FirstOrDefault(x => x.Id.Equals(userStoryId));

            return story.Subtasks;
        }

       public async Task UpdateAsync(Subtask subtask, Guid userStoryId)
        {
            await _context.SaveChangesAsync();
        }


    }
}
