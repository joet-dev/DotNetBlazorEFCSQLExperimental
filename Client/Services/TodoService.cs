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

        public async Task<Todo> UpdateTodo(Todo todo)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/todo/{todo.Id}", todo);
            var restodo = await result.Content.ReadFromJsonAsync<Todo>();
            return restodo; 
        }

        public async Task<Todo> RemoveTodo(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<Todo>($"api/todo/{id}"); 
        }
    }
}
