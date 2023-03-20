using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.BusinessLogic.Models;
using ToDoCosmos.Domain;
using ToDoCosmos.BusinessLogic.Exceptions;

namespace ToDoCosmos.BusinessLogic.Implementation
{
    public class SubtaskService : ISubtaskService
    {
        private readonly ISubtaskRepository _repository;

        public SubtaskService(ISubtaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Subtask> CreateSubtaskAsync(CreateSubtaskDTO subtaskDTO, Guid usertSoryId)
        {
            var subtask = new Subtask
            {
                Id = Guid.NewGuid(),
                Name = subtaskDTO.Name,
                Description = subtaskDTO.Description,
               

            };

            await _repository.AddAsync(subtask, usertSoryId);
            return subtask;


        }

      public async Task ChangeStatusAsync(Guid subtaskid, Guid userStoryId, string status)
        {

            var subtasks = await _repository.GetAllSubtasksAsync(userStoryId);
            var subtask = subtasks.FirstOrDefault(x => x.Id == subtaskid);
            

            if (subtask is null)
            {
                throw new JiraNotFoundException();
            }

            subtask.Status = status;

            await _repository.UpdateAsync(subtask, userStoryId);
        }

       public async Task UpdateSubtaskAsync(UpdateSubtaskDTO subtaskDto, Guid userStoryId)
        {
            var subtasks = await _repository.GetAllSubtasksAsync(userStoryId);
            var subtask = subtasks.FirstOrDefault(x => x.Id == subtaskDto.Id);

            if (subtask is null)
            {
                throw new JiraNotFoundException();
            }

            subtask.Name = subtaskDto.Name;
            subtask.Description = subtaskDto.Description;
            subtask.AssigneeId = subtaskDto.AssigneeId;
           
            await _repository.UpdateAsync(subtask, userStoryId);
        }

    }
}
