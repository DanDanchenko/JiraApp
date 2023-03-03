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
    public class JiraRepository : IUStoryRepository
    {

        private readonly JiraContext _context;
        private readonly IUserService _userService;

        public JiraRepository(JiraContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        /*    public async Task AddAsync(UserStory)
            {
                var userId = _userService.CurrentUserId;

                var user = await _context.Users.FirstAsync(x => x.Id.Equals(userId));
                user. ??= new List<ToDoItem>();

                user.ToDoItems.Add(item);

                await _context.SaveChangesAsync();
            }*/

        public async Task<IEnumerable<UserStory>> GetAllDoneStoriesAsync()
        {
            var allItems = await GetAllStoriesAsync();
            return allItems.Where(x => x.IsDone).ToList();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllItemsAsync()
        {
            var storyid = _userService.CurrentUserId;

            var user = await _context.Users.FirstAsync(x => x.Id == userId);

            return user.ToDoItems;
        }
    }
}
