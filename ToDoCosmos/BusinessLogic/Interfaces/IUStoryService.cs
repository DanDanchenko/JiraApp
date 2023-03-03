using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.BusinessLogic.Models;
using ToDoCosmos.Domain;

namespace ToDoCosmos.BusinessLogic.Interfaces
{
    public interface IUStoryService
    {
        Task<UserStory> CreateStoryAsync(CreateUserStoryDTO storyDto);
        Task<IEnumerable<UserStory>> GetAllStoriesAsync();
        Task<IEnumerable<UserStory>> GetAllDoneStoriesAsync();
        Task<UserStory> GetStoryByIdAsync(Guid storyid);
        Task ChangeStatusAsync(Guid storyid, string status);
        Task UpdateStoryAsync(UpdateUserStoryDTO storyDto);
    }
}
