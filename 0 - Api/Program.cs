using CurotecTaskBackApi;
using CurotecTaskBackApi.CrossCutting;
using CurotecTaskBackApi.Infra;
using CurotecTaskBackApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using CurotecTaskBackApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

// Add SignalR services
builder.Services.AddSignalR();

// Register services from IoC
IoC.RegisterServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
    DbInitializer.Seed(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add a middleware for global error handling
app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.UseHttpsRedirection();

// Use CORS in the application
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Map SignalR hubs
app.MapHub<TaskHub>("/hub");

// Add a redirect to Swagger UI when accessing the root URL
app.MapGet(
    "/",
    context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    }
);

app.Run();
