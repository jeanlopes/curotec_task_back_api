using CurotecTaskBackApi.Handlers;
using CurotecTaskBackApi.Queries;
using CurotecTaskBackApi.Repositories;
using CurotecTaskBackApi.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CurotecTaskBackApi.CrossCutting
{
    public static class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<ITaskRepository, TaskRepository>();

            // Register services
            services.AddScoped<ITaskService, TaskService>();

            // Register CQRS handlers and queries
            services.AddScoped<CreateTaskHandler>();
            services.AddScoped<UpdateTaskHandler>();
            services.AddScoped<DeleteTaskHandler>();
            services.AddScoped<TaskQueries>();
        }
    }
}
