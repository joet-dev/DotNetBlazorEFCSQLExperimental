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

        //public async void UpdateTodo(Todo todo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
