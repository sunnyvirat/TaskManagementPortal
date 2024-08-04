namespace TaskManagementPortal.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }

    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    public class Tasks
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public Employee AssignedEmployee { get; set; }
        public int CreatedBy { get; set; }
        public Employee CreatedEmployee { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<TaskNote> Notes { get; set; }
        public ICollection<TaskDocument> Documents { get; set; }
    }

    public class TaskNote
    {
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public Employee CreatedEmployee { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TaskDocument
    {
        public int DocumentId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string DocumentPath { get; set; }
        public int UploadedBy { get; set; }
        public Employee UploadedEmployee { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
