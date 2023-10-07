using CapitalPlacement.Domain.Models;
using CapitalPlacement.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CapitalPlacement.Api.Controllers
{
    [Route("api/applicationforms")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormRepository _repository;

        public ApplicationFormController(IApplicationFormRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationForm>> GetApplicationFormAsync(string id)
        {
            try
            {
                var applicationForm = await _repository.GetApplicationFormAsync(id);
                if (applicationForm == null)
                {
                    return NotFound();
                }

                return Ok(applicationForm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationFormAsync(string id, ApplicationForm applicationForm)
        {
            try
            {
                if (id != applicationForm.ApplicationFormId)
                {
                    return BadRequest();
                }

                var updatedApplicationForm = await _repository.UpdateApplicationFormAsync(applicationForm);
                if (updatedApplicationForm == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
