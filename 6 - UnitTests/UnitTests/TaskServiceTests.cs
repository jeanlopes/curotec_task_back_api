using CurotecTaskBackApi.Repositories;
using CurotecTaskBackApi.Services;
using Domain.Services;
using Moq;

namespace UnitTests;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepository;
    private readonly ITaskService _taskService;

    public TaskServiceTests()
    {
        _mockRepository = new Mock<ITaskRepository>();
        _taskService = new TaskService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllTasksAsync_ShouldReturnTasks()
    {
        // Arrange
        var tasks = new List<CurotecTaskBackApi.Entities.Task>
        {
            new()
            {
                Id = 1,
                Title = "Task 1",
                Description = "Description 1"
            },
            new()
            {
                Id = 2,
                Title = "Task 2",
                Description = "Description 2"
            }
        };
        _mockRepository.Setup(repo => repo.GetAllTasksAsync()).ReturnsAsync(tasks);

        // Act
        var result = await _taskService.GetAllTasksAsync();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal("Task 1", result.First().Title);
    }

    [Fact]
    public async Task AddTaskAsync_ShouldAddTask()
    {
        // Arrange
        var task = new CurotecTaskBackApi.Entities.Task
        {
            Id = 1,
            Title = "New Task",
            Description = "New Description"
        };
        _mockRepository.Setup(repo => repo.AddTaskAsync(task)).ReturnsAsync(task);

        // Act
        var result = await _taskService.AddTaskAsync(task);

        // Assert
        Assert.Equal("New Task", result.Title);
        _mockRepository.Verify(repo => repo.AddTaskAsync(task), Times.Once);
    }
}
