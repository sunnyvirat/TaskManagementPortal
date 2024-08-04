using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            try
            {
                return await _teamRepository.GetTeamsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving teams", ex);
            }
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            try
            {
                return await _teamRepository.GetTeamByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving team with ID {id}", ex);
            }
        }

        public async Task CreateTeamAsync(Team team)
        {
            try
            {
                await _teamRepository.CreateTeamAsync(team);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating team", ex);
            }
        }

        public async Task UpdateTeamAsync(Team team)
        {
            try
            {
                await _teamRepository.UpdateTeamAsync(team);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating team", ex);
            }
        }

        public async Task DeleteTeamAsync(int id)
        {
            try
            {
                await _teamRepository.DeleteTeamAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting team with ID {id}", ex);
            }
        }
    }

}
