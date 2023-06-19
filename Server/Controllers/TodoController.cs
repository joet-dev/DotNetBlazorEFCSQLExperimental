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
            var todos = await _context.Todo.ToListAsync();
            return Ok(todos); 
        }

        // Get todo by id. 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTodo(int id)
        {
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
            _context.Todo.Add(todo);
            await _context.SaveChangesAsync(); 

            return Ok(await GetTodos()); 
        }

        // Update todo.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo todo)
        {
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
            var updateTodo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (updateTodo == null)
            {
                return NotFound("Todo not found.");
            }

            updateTodo.IsDone = !updateTodo.IsDone;

            await _context.SaveChangesAsync();

            return Ok(); 
        }

        // Delete todo.
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTodo(int id)
        {
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
