using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupremeCourtRecords.Models;

namespace SupremeCourtRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetitionersController : ControllerBase
    {
        private readonly IPetitionerService _petitionerService;
        private readonly ILogger<PetitionersController> _logger;

        public PetitionersController(IPetitionerService petitionerService, ILogger<PetitionersController> logger)
        {
            _petitionerService = petitionerService;
            _logger = logger;
        }

        // GET: api/Petitioners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Petitioner>>> GetPetitioners()
        {
            try
            {
                _logger.LogInformation("Fetching all petitioners.");
                var petitioners = await _petitionerService.GetAllPetitionersAsync();
                if (petitioners == null || !petitioners.Any())
                {
                    _logger.LogWarning("No petitioners found.");
                    return NotFound("No petitioners found.");
                }
                return Ok(petitioners);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching petitioners.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Petitioners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Petitioner>> GetPetitioner(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching petitioner with ID {id}");
                var petitioner = await _petitionerService.GetPetitionerByIdAsync(id);

                if (petitioner == null)
                {
                    _logger.LogWarning($"Petitioner with ID {id} not found.");
                    return NotFound($"Petitioner with ID {id} not found.");
                }

                return Ok(petitioner);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the petitioner.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Petitioners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetitioner(int id, Petitioner petitioner)
        {
            try
            {
                if (id != petitioner.PetitionerId)
                {
                    _logger.LogWarning("Petitioner ID mismatch.");
                    return BadRequest("Petitioner ID mismatch.");
                }

                await _petitionerService.UpdatePetitionerAsync(id, petitioner);
                _logger.LogInformation($"Petitioner with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _petitionerService.GetPetitionerByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Petitioner with ID {id} not found for update.");
                    return NotFound($"Petitioner with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating petitioner.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the petitioner.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Petitioners
        [HttpPost]
        public async Task<ActionResult<Petitioner>> PostPetitioner(Petitioner petitioner)
        {
            try
            {
                if (petitioner == null)
                {
                    _logger.LogWarning("Received empty petitioner object.");
                    return BadRequest("Petitioner data cannot be null.");
                }

                await _petitionerService.AddPetitionerAsync(petitioner);
                _logger.LogInformation($"Petitioner with ID {petitioner.PetitionerId} created.");
                return CreatedAtAction("GetPetitioner", new { id = petitioner.PetitionerId }, petitioner);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the petitioner.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Petitioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetitioner(int id)
        {
            try
            {
                var petitioner = await _petitionerService.GetPetitionerByIdAsync(id);
                if (petitioner == null)
                {
                    _logger.LogWarning($"Petitioner with ID {id} not found.");
                    return NotFound($"Petitioner with ID {id} not found.");
                }

                await _petitionerService.DeletePetitionerAsync(id);
                _logger.LogInformation($"Petitioner with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the petitioner.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}