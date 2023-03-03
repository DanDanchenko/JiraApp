using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
                Description = storyDto.Description,
                Assignee = storyDto.Assignee,
                Subtasks = storyDto.Subtasks,
                Status = storyDto.Status,

            };
            await _repository.AddAsync(story);
            return story;   


        }

       public async Task<IEnumerable<UserStory>> GetAllStoriesAsync()
        {
            return await _repository.GetAllStoriesAsync();
        }

      public  async Task<IEnumerable<UserStory>> GetAllDoneStoriesAsync()
        {
            return await _repository.GetAllDoneStoriesAsync();
        }

    public async Task<UserStory> GetStoryByIdAsync(Guid storyid)
        {

            var stories = await _repository.GetAllStoriesAsync();
            var story = stories.FirstOrDefault(x => x.Id == storyid);



            return story;

        }

     public async Task ChangeStatusAsync(Guid storyid, string status)
        {
            var stories = await _repository.GetAllStoriesAsync();
            var story = stories.FirstOrDefault(x => x.Id == storyid);

            story.Status = "";

            await _repository.UpdateAsync(story);
        }

       public async Task UpdateStoryAsync(UpdateUserStoryDTO storyDto)
        {
          
            var story = await _repository.GetByIdAsync(storyDto.Id);

            story.Status = storyDto.Status;
            story.Name = storyDto.Status;
            story.Description = storyDto.Description;
            story.Assignee = storyDto.Assignee;
            story.Subtasks = storyDto.Subtasks;

            await _repository.UpdateAsync(story); 




        }




    }
}
