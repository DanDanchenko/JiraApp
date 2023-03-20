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
    public class SubtasksController : ControllerBase
    {
        private readonly ISubtaskService _service;

        public SubtasksController(ISubtaskService service)
        {
            _service = service;
        }

        [HttpPost]

        public async Task<ActionResult<Subtask>> CreateSubtaskASync(CreateSubtaskDTO subtaskDTO, Guid userStoryId)
        {
            var createdsubtask = await _service.CreateSubtaskAsync(subtaskDTO, userStoryId);
            return Ok(createdsubtask);
        }

        [HttpPut("{subtaskid}")]
        public async Task<ActionResult> ChangeStatusAsync(Guid subtaskid, Guid userStoryId, string status)
        {
            await _service.ChangeStatusAsync(subtaskid, userStoryId, status);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult> UpdateSubtaskAsync(UpdateSubtaskDTO subtaskDTO, Guid userStoryId)
        {
            await _service.UpdateSubtaskAsync(subtaskDTO, userStoryId);
            return Ok();
        }

        
    }
}
