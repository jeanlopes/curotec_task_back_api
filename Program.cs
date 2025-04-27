using CurotecTaskBackApi;
using CurotecTaskBackApi.Handlers;
using CurotecTaskBackApi.Middlewares;
using CurotecTaskBackApi.Queries;
using CurotecTaskBackApi.Repositories;
using CurotecTaskBackApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

// Register CQRS handlers and queries
builder.Services.AddScoped<CreateTaskHandler>();
builder.Services.AddScoped<UpdateTaskHandler>();
builder.Services.AddScoped<DeleteTaskHandler>();
builder.Services.AddScoped<TaskQueries>();

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add a middleware for global error handling
app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
