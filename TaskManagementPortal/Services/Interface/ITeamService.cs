using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<Team> GetTeamByIdAsync(int id);
        Task CreateTeamAsync(Team team);
        Task UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
    }
}
