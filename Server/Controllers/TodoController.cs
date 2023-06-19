using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetBlazorEFCSQLExperimental.Shared; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace DotNetBlazorEFCSQLExperimental.Server.Controllers
{
    [Route("api/[controller]")] // [controller] is an identifier from the class name. In this case it is Todo. 
    [ApiController]
    public class TodoController : ControllerBase
    {
        static List<Todo> todos = new List<Todo>();

        // Get all todos. 
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(todos); 
        }

        // Get todo by id. 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTodo(int id)
        {
            var todo = todos.FirstOrDefault(x => x.Id == id);
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
            if (todos.Count > 0)
            {
                todo.Id = todos.Max(t => t.Id + 1);
            }
            else
            {
                todo.Id = 1;
            }
            todos.Add(todo);

            return Ok(todos); 
        }

        // Update todo.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo todo)
        {
            var item = todos.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound("Todo not found.");
            }

            var todoidx = todos.IndexOf(item); 
            todos[todoidx] = todo; 

            return Ok(todo);
        }

        // Update todo state. 
        [HttpPut]
        
        public async Task<IActionResult> UpdateTodoState(int id)
        {
            Console.WriteLine($"SERVER: This is the id requested for state change: {id}"); 
            var item = todos.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound("Todo not found.");
            }

            var todoidx = todos.IndexOf(item);
            todos[todoidx].IsDone = !todos[todoidx].IsDone;

            return Ok(); 
        }

        // Delete todo.
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTodo(int id)
        { 
            var item = todos.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
               return NotFound("Todo not found.");
            }

            todos.Remove(item);

            return Ok(item);
        }
    }
}
