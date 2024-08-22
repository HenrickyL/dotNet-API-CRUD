using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/cohorts")]
public class CohortController : ControllerBase
{
    private readonly CohortService _cohortService;

    public CohortController(CohortService cohortService)
    {
        _cohortService = cohortService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cohort>>> GetAllCohorts()
    {
        var cohorts = await _cohortService.GetAllCohortsAsync();
        return Ok(cohorts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cohort?>> GetCohort(string id)
    {
        var cohort = await _cohortService.GetCohortByIdAsync(id);
        if (cohort == null)
            return NotFound();

        return Ok(cohort);
    }

    [HttpPost]
    public async Task<ActionResult> AddCohort([FromBody] Cohort cohort)
    {
        await _cohortService.AddCohortAsync(cohort);
        return CreatedAtAction(nameof(GetCohort), new { id = cohort.Id }, cohort);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCohort(string id, [FromBody] Cohort cohort)
    {
        await _cohortService.UpdateCohortAsync(id, cohort);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCohort(string id)
    {
        await _cohortService.RemoveCohortAsync(id);
        return NoContent();
    }
}

