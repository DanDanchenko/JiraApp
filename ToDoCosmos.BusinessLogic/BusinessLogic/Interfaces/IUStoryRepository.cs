using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.Domain;
using ToDoCosmos.BusinessLogic.Models;

namespace ToDoCosmos.BusinessLogic.Interfaces
{
    public interface IUStoryRepository
    {
        Task AddAsync(UserStory story);
        Task<UserStory> GetByIdAsync(Guid Id);
        Task<IEnumerable<UserStory>> GetAllStoriesAsync();
        Task UpdateAsync(UserStory story);
    }
}
