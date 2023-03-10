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

        public async Task<Subtask> CreateSubtaskAsync(CreateSubtaskDTO subtaskDTO)
        {
            var subtask = new Subtask
            {
                Id = Guid.NewGuid(),
                Name = subtaskDTO.Name,
                Description = subtaskDTO.Description,
               

            };

            await _repository.AddAsync(subtask);
            return subtask;


        }

      public async Task ChangeStatusAsync(Guid subtaskid, string status)
        {
           
            var subtask = await _repository.GetByIdAsync(subtaskid);

            if (subtask is null)
            {
                throw new JiraNotFoundException();
            }

            subtask.Status = status;

            await _repository.UpdateAsync(subtask);
        }

       public async Task UpdateSubtaskAsync(UpdateSubtaskDTO subtaskDto)
        {
            var subtask = await _repository.GetByIdAsync(subtaskDto.Id);

            if (subtask is null)
            {
                throw new JiraNotFoundException();
            }

            subtask.Name = subtaskDto.Name;
            subtask.Description = subtaskDto.Description;
            subtask.Assignee = subtaskDto.Assignee;
           
            await _repository.UpdateAsync(subtask);
        }

    }
}
