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
        List<Todo> todos = new List<Todo>
        {
            new Todo { Id=1, Title="TestTitle", IsDone=false, Priority=5, Note="TestNote", Created=DateTime.Now, Duration=10 },
            new Todo { Id=2, Title="TestTitle2", IsDone=false, Priority=6, Note="TestNote2", Created=DateTime.Now, Duration=10 }
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

        //[HttpPut]
        //public async Task<IActionResult> UpdateTodo()
        //{

        //}
    }
}
