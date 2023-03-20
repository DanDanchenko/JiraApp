using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.BusinessLogic.Models;
using ToDoCosmos.Domain;

namespace JiraApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoriesController : ControllerBase
    {
        private readonly IUStoryService _service;

        public UserStoriesController(IUStoryService service)
        {
            _service = service;
        }

        [HttpPost]

        public async Task<ActionResult<UserStory>> CreateUserStoryAsync(CreateUserStoryDTO storyDto)
        {
            var createdStory = await _service.CreateStoryAsync(storyDto);
            return Ok(createdStory);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStory>>> GetAllStoriesAsync()
        {
            return Ok(await _service.GetAllStoriesAsync());
        }

        [HttpGet("{storyid}")]
        public async Task<ActionResult<UserStory>> GetStoryByIdAsync(Guid storyid)
        {
            return Ok(await _service.GetStoryByIdAsync(storyid));
        }

        [HttpPut("{storyid}")]

        public async Task<ActionResult> ChangeStatusAsync(Guid storyid, string staatus)
        {
            await _service.ChangeStatusAsync(storyid, staatus);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult> UpdateStoryAsync(UpdateUserStoryDTO storyDto)
        {
            await _service.UpdateStoryAsync(storyDto);
            return Ok();
        }
       

    }
}
