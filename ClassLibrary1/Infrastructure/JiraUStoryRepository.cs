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
    public class JiraUStoryRepository : IUStoryRepository
    {

        private readonly JiraContext _context;
        private readonly IUserService _userService;
        

        public JiraUStoryRepository(JiraContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

          public async Task AddAsync(UserStory userStory)
            {
                var userId = _userService.CurrentUserId;

                var assignee = await _context.Users.FirstAsync(x => x.Id.Equals(userId));
                userStory.AssigneeId = assignee.Id;

                userStory.Status = "";

               _context.Stories.Add(userStory);

                await _context.SaveChangesAsync();
            }

        public async Task<UserStory> GetByIdAsync(Guid Id)
        {
            var stories = await GetAllStoriesAsync();

            return stories.FirstOrDefault(x => x.Id == Id);
        }

        public async Task<IEnumerable<UserStory>> GetAllStoriesAsync()
        {
            return _context.Stories;
        }

       public async Task UpdateAsync(UserStory story)
        {
            await _context.SaveChangesAsync();
        }
    }
}
