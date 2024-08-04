using Microsoft.AspNetCore.Mvc;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamService.GetTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _teamService.CreateTeamAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamId)
            {
                return BadRequest();
            }

            await _teamService.UpdateTeamAsync(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }

}
