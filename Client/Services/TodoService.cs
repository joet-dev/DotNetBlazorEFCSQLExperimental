using DotNetBlazorEFCSQLExperimental.Shared;
using System.Net.Http.Json;

namespace DotNetBlazorEFCSQLExperimental.Client.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient) 
        {
           _httpClient = httpClient;
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await _httpClient.GetFromJsonAsync<Todo>($"api/todo/{id}");
        }

        public async Task<List<Todo>> GetTodos()
        {
            return await _httpClient.GetFromJsonAsync<List<Todo>>("api/todo");
        }

        public async Task<List<Todo>> CreateTodo(Todo todo)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/todo", todo);
            var todos = await result.Content.ReadFromJsonAsync<List<Todo>>();
            return todos; 
        }

        //public async void UpdateTodo(Todo todo)
        //{
        //    await _httpClient.PostAsJsonAsync($"api/todo", todo);
        //}
    }
}
