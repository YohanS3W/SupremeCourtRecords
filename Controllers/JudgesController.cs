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
    public class JudgesController : ControllerBase
    {
        private readonly IJudgeService _judgeService;
        private readonly ILogger<JudgesController> _logger;

        public JudgesController(IJudgeService judgeService, ILogger<JudgesController> logger)
        {
            _judgeService = judgeService;
            _logger = logger;
        }

        // GET: api/Judges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Judge>>> GetJudges()
        {
            try
            {
                _logger.LogInformation("Fetching all judges.");
                var judges = await _judgeService.GetAllJudgesAsync();
                if (judges == null || !judges.Any())
                {
                    _logger.LogWarning("No judges found.");
                    return NotFound("No judges found.");
                }
                return Ok(judges);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching judges.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Judges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Judge>> GetJudge(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching judge with ID {id}");
                var judge = await _judgeService.GetJudgeByIdAsync(id);

                if (judge == null)
                {
                    _logger.LogWarning($"Judge with ID {id} not found.");
                    return NotFound($"Judge with ID {id} not found.");
                }

                return Ok(judge);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the judge.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Judges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJudge(int id, Judge judge)
        {
            try
            {
                if (id != judge.JudgeId)
                {
                    _logger.LogWarning("Judge ID mismatch.");
                    return BadRequest("Judge ID mismatch.");
                }

                await _judgeService.UpdateJudgeAsync(id, judge);
                _logger.LogInformation($"Judge with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _judgeService.GetJudgeByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Judge with ID {id} not found for update.");
                    return NotFound($"Judge with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating judge.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the judge.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Judges
        [HttpPost]
        public async Task<ActionResult<Judge>> PostJudge(Judge judge)
        {
            try
            {
                if (judge == null)
                {
                    _logger.LogWarning("Received empty judge object.");
                    return BadRequest("Judge data cannot be null.");
                }

                await _judgeService.AddJudgeAsync(judge);
                _logger.LogInformation($"Judge with ID {judge.JudgeId} created.");
                return CreatedAtAction("GetJudge", new { id = judge.JudgeId }, judge);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the judge.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Judges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudge(int id)
        {
            try
            {
                var judge = await _judgeService.GetJudgeByIdAsync(id);
                if (judge == null)
                {
                    _logger.LogWarning($"Judge with ID {id} not found.");
                    return NotFound($"Judge with ID {id} not found.");
                }

                await _judgeService.DeleteJudgeAsync(id);
                _logger.LogInformation($"Judge with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the judge.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
