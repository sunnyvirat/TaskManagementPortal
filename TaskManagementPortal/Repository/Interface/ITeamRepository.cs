using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<Team> GetTeamByIdAsync(int id);
        Task CreateTeamAsync(Team team);
        Task UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
    }
}
