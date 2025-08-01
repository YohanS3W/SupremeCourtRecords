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
    public class RespondentsController : ControllerBase
    {
        private readonly IRespondentService _respondentService;
        private readonly ILogger<RespondentsController> _logger;

        public RespondentsController(IRespondentService respondentService, ILogger<RespondentsController> logger)
        {
            _respondentService = respondentService;
            _logger = logger;
        }

        // GET: api/Respondents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Respondent>>> GetRespondents()
        {
            try
            {
                _logger.LogInformation("Fetching all respondents.");
                var respondents = await _respondentService.GetAllRespondentsAsync();
                if (respondents == null || !respondents.Any())
                {
                    _logger.LogWarning("No respondents found.");
                    return NotFound("No respondents found.");
                }
                return Ok(respondents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching students.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Respondents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Respondent>> GetRespondent(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching respondent with ID {id}");
                var respondent = await _respondentService.GetRespondentByIdAsync(id);

                if (respondent == null)
                {
                    _logger.LogWarning($"Respondent with ID {id} not found.");
                    return NotFound($"Respondent with ID {id} not found.");
                }

                return Ok(respondent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the respondent.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Respondents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespondent(int id, Respondent respondent)
        {
            try
            {
                if (id != respondent.RespondentId)
                {
                    _logger.LogWarning("Respondent ID mismatch.");
                    return BadRequest("Respondent ID mismatch.");
                }

                await _respondentService.UpdateRespondentAsync(id, respondent);
                _logger.LogInformation($"Respondent with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _respondentService.GetRespondentByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Respondent with ID {id} not found for update.");
                    return NotFound($"Respondent with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating respondent.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the respondent.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Respondent
        [HttpPost]
        public async Task<ActionResult<Respondent>> PostRespondent(Respondent respondent)
        {
            try
            {
                if (respondent == null)
                {
                    _logger.LogWarning("Received empty respondent object.");
                    return BadRequest("Respondent data cannot be null.");
                }

                await _respondentService.AddRespondentAsync(respondent);
                _logger.LogInformation($"Respondent with ID {respondent.RespondentId} created.");
                return CreatedAtAction("GetRespondent", new { id = respondent.RespondentId }, respondent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the respondent.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Respondents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespondent(int id)
        {
            try
            {
                var respondent = await _respondentService.GetRespondentByIdAsync(id);
                if (respondent == null)
                {
                    _logger.LogWarning($"Respondent with ID {id} not found.");
                    return NotFound($"Respondent with ID {id} not found.");
                }

                await _respondentService.DeleteRespondentAsync(id);
                _logger.LogInformation($"Respondent with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the respondent.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}