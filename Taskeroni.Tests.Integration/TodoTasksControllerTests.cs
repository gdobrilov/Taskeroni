using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Taskeroni.Core.Entities;
using Taskeroni.Infrastructure.Data;
using Xunit;

public class TodoTasksControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _customizedFactory;

    public TodoTasksControllerTests(WebApplicationFactory<Program> factory)
    {
        _customizedFactory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TaskeroniDbContext>));
                services.Remove(descriptor);

                // Add a new DbContext using the InMemory provider.
                services.AddDbContext<TaskeroniDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });
            });
        });

        _client = _customizedFactory.CreateClient();
    }

    [Fact]
    public async Task CreateTodoTask_ShouldReturnCreated()
    {
        var newTask = new { Title = "Test Task", DueDate = DateTime.Now.AddDays(5) };
        var content = new StringContent(JsonConvert.SerializeObject(newTask), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/todotasks", content);

        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetPendingTasks_ShouldReturnTasks()
    {
        using var scope = _customizedFactory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TaskeroniDbContext>();
        dbContext.TodoTasks.Add(new TodoTask { Title = "Pending Task" });
        dbContext.SaveChanges();

        var response = await _client.GetAsync("/api/todotasks/pending");

        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsStringAsync();
        Assert.Contains("Pending Task", responseData);
    }
}