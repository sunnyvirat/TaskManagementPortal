using Microsoft.EntityFrameworkCore;
using TaskManagementPortal.DBContext;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TaskManagementContext _context;

        public TeamRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            try
            {
                return await _context.Teams.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting teams", ex);
            }
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            try
            {
                return await _context.Teams.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting team with ID {id}", ex);
            }
        }

        public async Task CreateTeamAsync(Team team)
        {
            try
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
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
                _context.Entry(team).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
                var team = await _context.Teams.FindAsync(id);
                if (team == null)
                {
                    throw new Exception($"Team with ID {id} not found");
                }
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting team with ID {id}", ex);
            }
        }
    }

}
