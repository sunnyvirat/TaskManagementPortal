using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaskManagementPortal.Models;

namespace TaskManagementPortal.DBContext
{
    public class TaskManagementContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<TaskDocument> TaskDocuments { get; set; }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and constraints here
        }
    }

}
