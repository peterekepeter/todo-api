using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace todo_api.Controllers
{
    // The job of this controller is to translates web requests to C# calls.
    // It should never have more code than calling some service from another class.

    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<TodoModel>), 200)]
        public IActionResult Get([FromServices] ITodoService todos)
        {
            return Ok(todos.GetAll());
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoModel), 200)]
        public IActionResult Get([FromRoute(Name = "id")] int id, [FromServices] ITodoService todos)
        {
            var todo = todos.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST api/todos
        [HttpPost]
        public IActionResult Post([FromBody]TodoCreateOrUpdateModel value, [FromServices] ITodoService todos)
        {
            todos.AddNew(value.Text); 
            return Ok();
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute(Name = "id")] int id, [FromBody]TodoCreateOrUpdateModel value, [FromServices] ITodoService todos)
        {
            if (todos.Update(id, value.Text))
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromServices] ITodoService todos)
        {
            if (todos.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
