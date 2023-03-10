using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.BusinessLogic.Exceptions;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.BusinessLogic.Models;
using ToDoCosmos.Domain;

namespace ToDoCosmos.BusinessLogic.Implementation
{
    public class UserStoryService : IUStoryService
    {
        private readonly IUStoryRepository _repository;

        public UserStoryService(IUStoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserStory> CreateStoryAsync(CreateUserStoryDTO storyDto)
        {
            var story = new UserStory
            {
                Id = Guid.NewGuid(),
                Name = storyDto.Name,
                Description = storyDto.Description

            };
            await _repository.AddAsync(story);
            return story;   


        }

       public async Task<IEnumerable<UserStory>> GetAllStoriesAsync()
        {
            var stories = await _repository.GetAllStoriesAsync();
            if (stories == null)
            {
                throw new JiraNotFoundException();
            }
            return stories;
        }

    

    public async Task<UserStory> GetStoryByIdAsync(Guid storyid)
        {
            var story = await _repository.GetByIdAsync(storyid);

            if (story is null)
            {
                throw new JiraNotFoundException();
            }
            return story;

        }

     public async Task ChangeStatusAsync(Guid storyid, string status)
        {
            var stories = await _repository.GetAllStoriesAsync();
            var story = stories.FirstOrDefault(x => x.Id == storyid);

            if (story is null)
            {
                throw new JiraNotFoundException();
            }

            story.Status = status;

            await _repository.UpdateAsync(story);
        }

       public async Task UpdateStoryAsync(UpdateUserStoryDTO storyDto)
        {
          
            var story = await _repository.GetByIdAsync(storyDto.Id);

            if (story is null)
            {
                throw new JiraNotFoundException();
            }

            story.Name = storyDto.Name;
            story.Description = storyDto.Description;
            story.Assignee = storyDto.Assignee;

            await _repository.UpdateAsync(story); 




        }




    }
}
