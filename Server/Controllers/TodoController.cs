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
        static List<Todo> todos = new List<Todo>
        {
            new Todo { Id=4, Title="TEST", IsDone=false, Priority=4, Note="TEST", Created=DateTime.Now, Due=DateTime.Now, Duration=10  },
            new Todo { Id=0, Title="TestZero", IsDone=false, Priority=4, Note="Testing...", Created=DateTime.Now, Due=DateTime.Now, Duration=10 },
            new Todo { Id=1, Title="TestTitle", IsDone=false, Priority=5, Note="TestNote", Created=DateTime.Now, Due=DateTime.Now, Duration=10 },
            new Todo { Id=2, Title="TestTitle2", IsDone=false, Priority=6, Note="TestNote2", Created=DateTime.Now, Due=DateTime.Now, Duration=10 }
        };

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(todos); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTodo(int id)
        {
            var todo = todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound("Todo wasn't found. Too bad. :("); 
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todo todo)
        {
            todo.Id = todos.Max(t => t.Id + 1); 
            todos.Add(todo);

            return Ok(todos); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo todo)
        {
            var item = todos.SingleOrDefault(x => x.Id == id);
            if (item != null) todos.Remove(item);

            todos.Add(todo); 

            return Ok();
        }
    }
}
