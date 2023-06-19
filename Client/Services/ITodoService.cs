using DotNetBlazorEFCSQLExperimental.Shared; 

namespace DotNetBlazorEFCSQLExperimental.Client.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> GetTodo(int id);
        Task<Todo> CreateTodo(Todo todo);
        Task<Todo> UpdateTodo(Todo todo);

        Task<Todo> UpdateTodoState(int id); 
        Task<Todo> RemoveTodo(int id);
    }
}
