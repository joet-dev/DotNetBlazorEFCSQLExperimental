using DotNetBlazorEFCSQLExperimental.Shared;
using System.Net;
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

        public async Task<Todo> CreateTodo(Todo todo)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/todo", todo);
            var restodo = await result.Content.ReadFromJsonAsync<Todo>();
            return restodo;
        }

        public async Task<Todo> UpdateTodo(Todo todo)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/todo/{todo.Id}", todo);
            var resTodo = await res.Content.ReadFromJsonAsync<Todo>();
            return resTodo; 
        }

        public async Task<Todo> UpdateTodoState(int id)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/todo/{id}/changestate", id);
            var resTodo = await res.Content.ReadFromJsonAsync<Todo>();
            return resTodo; 
        }

        public async Task<Todo> RemoveTodo(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<Todo>($"api/todo/{id}"); 
        }
    }
}
