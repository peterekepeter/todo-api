using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_api.Models;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        static readonly ConcurrentDictionary<int, TodoModel> todoRepository = new ConcurrentDictionary<int, TodoModel>();
        static int _idGenerator = 0;

        // GET api/todos
        [HttpGet]
        [ProducesResponseType(typeof(List<TodoModel>), 200)]
        public IActionResult Get()
        {
            return Ok(todoRepository.Values.ToList());
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoModel), 200)]
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            if (todoRepository.TryGetValue(id, out var todo))
            {
                return Ok(todo);
            }
            return NotFound();
        }

        // POST api/todos
        [HttpPost]
        public IActionResult Post([FromBody]TodoCreateOrUpdateModel value)
        {
            var todo = new TodoModel();
            todo.Created = DateTimeOffset.Now;
            todo.Text = value.Text;
            _idGenerator += 1;
            todo.Id = _idGenerator;
            todoRepository.AddOrUpdate(_idGenerator, i => todo, (i, model) => todo);
            return Ok();
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute(Name = "id")] int id, [FromBody]TodoCreateOrUpdateModel value)
        {
            if (todoRepository.TryGetValue(id, out var todo))
            {
                todo.Text = value.Text;
                todo.Updated = DateTimeOffset.Now;
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            if (todoRepository.TryRemove(id, out var todo))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
