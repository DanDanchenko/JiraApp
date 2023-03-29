using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.BusinessLogic.Models;
using ToDoCosmos.Domain;
using ToDoCosmos.BusinessLogic.Models;

namespace JiraApi.Controllers
{
    [Authorize]
    [Route("api/subtasks")]
    [ApiController]
    public class SubtasksController : ControllerBase
    {
        private readonly ISubtaskService _service;

        public SubtasksController(ISubtaskService service)
        {
            _service = service;
        }

        [HttpPost]

        public async Task<ActionResult<Subtask>> CreateSubtaskASync(CreateSubtaskDTO subtaskDTO)
        {
            var createdsubtask = await _service.CreateSubtaskAsync(subtaskDTO);
            return Ok(createdsubtask);
        }

        [HttpPut("{subtaskid}")]
        public async Task<ActionResult> ChangeStatusAsync(ChangeSubtaskStatusDTO subtaskDTO, string status)
        {
            await _service.ChangeStatusAsync(subtaskDTO, status);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult> UpdateSubtaskAsync(UpdateSubtaskDTO subtaskDTO)
        {
            await _service.UpdateSubtaskAsync(subtaskDTO);
            return Ok();
        }

        
    }
}
