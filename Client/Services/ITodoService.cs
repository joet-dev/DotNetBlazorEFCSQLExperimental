using DotNetBlazorEFCSQLExperimental.Shared; 

namespace DotNetBlazorEFCSQLExperimental.Client.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> GetTodo(int id);

        //Task<Todo> UpdateTodo(Todo todo);
    }
}
