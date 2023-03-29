using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.Domain;
using ToDoCosmos.BusinessLogic.Models;

namespace ToDoCosmos.BusinessLogic.Interfaces
{
    public interface ISubtaskRepository
    {
        Task AddAsync(Subtask subtask, Guid userStoryId);
        Task<IEnumerable<Subtask>> GetAllSubtasksAsync(Guid userStoryId);
        Task UpdateAsync(Subtask subtask, Guid userStoryId);
    }
}
