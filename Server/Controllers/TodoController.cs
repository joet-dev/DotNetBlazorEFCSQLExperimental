using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetBlazorEFCSQLExperimental.Shared; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetBlazorEFCSQLExperimental.Server.Data;

namespace DotNetBlazorEFCSQLExperimental.Server.Controllers
{
    [Route("api/[controller]")] // [controller] is an identifier from the class name. In this case it is Todo. 
    [ApiController]
    public class TodoController : ControllerBase
    {
        //static List<Todo> todos = new List<Todo>();
        // Change IActionResults to Task<ActionResult<List<Todo>>>

        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context; 
        }

        // Get all todos. 
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            Console.WriteLine("\nHTTP GET: api/todo\nFUNC: GetTodos()\n");

            var todos = await _context.Todo.ToListAsync();
            return Ok(todos); 
        }

        // Get todo by id. 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTodo(int id)
        {
            Console.WriteLine("\nHTTP GET: api/todo/{id}\nFUNC: GetSingleTodo(int)\n");

            var todo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
            {
                return NotFound("Todo not found.");
            }

            return Ok(todo);
        }

        // Create todo.
        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todo todo)
        {
            Console.WriteLine("\nHTTP POST: api/todo\nFUNC: CreateTodo(Todo)\n");

            _context.Todo.Add(todo);
            await _context.SaveChangesAsync(); 

            return Ok(todo); 
        }

        // Update todo.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo todo)
        {
            Console.WriteLine("\nHTTP PUT: api/todo/{id}\nFUNC: UpdateTodo(int, Todo)\n");

            var updateTodo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (updateTodo == null)
            {
                return NotFound("Todo not found.");
            }

            updateTodo.Title = todo.Title;
            updateTodo.Note = todo.Note;
            updateTodo.Priority = todo.Priority;
            updateTodo.Duration = todo.Duration;
            updateTodo.Due = todo.Due;

            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        // Update todo state. 
        [HttpPut]
        [Route("{id}/changestate")]
        public async Task<IActionResult> UpdateTodoState(int id)
        {
            Console.WriteLine("\nHTTP PUT: api/todo/{id}/changestate\nFUNC: UpdateTodoState(int)\n");

            var updateTodo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (updateTodo == null)
            {
                return NotFound("Todo not found.");
            }

            updateTodo.IsDone = !updateTodo.IsDone;
            if (updateTodo.IsDone)
            {
                updateTodo.Completed = DateTime.Now; 
            }
            else
            {
                updateTodo.Completed = null; 
            }

            await _context.SaveChangesAsync();

            return Ok(updateTodo); 
        }

        // Delete todo.
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTodo(int id)
        {
            Console.WriteLine("\nHTTP DELETE: api/todo/{id}\nFUNC: RemoveTodo(int)\n");

            var deleteTodo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteTodo == null)
            {
                return NotFound("Todo not found.");
            }

            _context.Todo.Remove(deleteTodo);

            await _context.SaveChangesAsync();

            return Ok(deleteTodo);
        }
    }
}
