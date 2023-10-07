using CapitalPlacement.Domain.Models;
using CapitalPlacement.Infrastructure.Interfaces; 
using Microsoft.AspNetCore.Mvc;


namespace CapitalPlacement.Api.Controllers
{
    [Route("api/programdetails")]
    [ApiController]
    public class ProgramDetailsController : ControllerBase
    {
        private readonly IProgramDetailsRepository _repository; 

        public ProgramDetailsController(IProgramDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<ProgramDetails>> CreateProgramDetails(ProgramDetails programDetails)
        {
            try
            {
                var createdProgram = await _repository.CreateProgramDetailsAsync(programDetails);
                return CreatedAtAction(nameof(GetProgramDetails), new { id = createdProgram.ProgramDetailsId }, createdProgram);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramDetails>> GetProgramDetails(string id)
        {
            try
            {
                var programDetails = await _repository.GetProgramDetailsAsync(id);
                if (programDetails == null)
                {
                    return NotFound();
                }
                return Ok(programDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProgramDetails>> UpdateProgramDetails(string id, ProgramDetails programDetails)
        {
            try
            {
                if (id != programDetails.ProgramDetailsId)
                {
                    return BadRequest("ID mismatch");
                }

                var updatedProgram = await _repository.UpdateProgramDetailsAsync(programDetails);
                if (updatedProgram == null)
                {
                    return NotFound();
                }

                return Ok(updatedProgram);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramDetails(string id)
        {
            try
            {
                await _repository.DeleteProgramDetailsAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
