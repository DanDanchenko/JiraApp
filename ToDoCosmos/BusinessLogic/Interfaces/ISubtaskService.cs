using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.BusinessLogic.Models;
using ToDoCosmos.Domain;

namespace ToDoCosmos.BusinessLogic.Interfaces
{
    public interface ISubtaskService
    {
        Task<Subtask> CreateSubtaskAsync(CreateSubtaskDTO subtaskDto, Guid userStoryId);
        Task ChangeStatusAsync(Guid subtaskid, Guid userStoryId, string status);
        Task UpdateSubtaskAsync(UpdateSubtaskDTO subtaskDto, Guid userStoryId);
    }
}
