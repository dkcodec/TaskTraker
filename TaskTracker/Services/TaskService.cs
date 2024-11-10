using System.Net.Http.Json;
using TaskTrackerAPI.Data;

namespace TaskTracker.Services
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>("api/TaskItems");
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _httpClient.PostAsJsonAsync("api/TaskItems", task);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _httpClient.PutAsJsonAsync($"api/TaskItems/{task.Id}", task);
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            await _httpClient.DeleteAsync($"api/TaskItems/{taskId}");
        }
    }
}