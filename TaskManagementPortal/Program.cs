using TaskManagementPortal.DBContext;
using TaskManagementPortal.Repository;
using TaskManagementPortal.Services.Interface;
using TaskManagementPortal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext with a connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskManagementContext>(options =>
    options.UseSqlServer(connectionString));

// Register repositories
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskNoteRepository, TaskNoteRepository>();
builder.Services.AddScoped<ITaskDocumentRepository, TaskDocumentRepository>();

// Register services
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskNoteService, TaskNoteService>();
builder.Services.AddScoped<ITaskDocumentService, TaskDocumentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
