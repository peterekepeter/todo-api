using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services
{
    /// <summary>
    /// Memory implementation of ITodoService
    /// </summary>
    public class MemoryTodoService : ITodoService
    {
        // don't expose inner workings
        private ConcurrentDictionary<int, TodoModel> _todoRepository = new ConcurrentDictionary<int, TodoModel>();
        private int _idGenerator = 0;

        public MemoryTodoService()
        {
            // add some builtin messages, that can be initially displayed
            // can delete these later
            this.AddNew("Finish the project!");
            this.AddNew("Never give up!");
        }

        public List<TodoModel> GetAll()
        {
            return _todoRepository.Values.ToList();
        }
        
        public TodoModel GetById(int id)
        {
            if (_todoRepository.TryGetValue(id, out var todo))
            {
                return todo;
            }
            return null;
        }
        
        public void AddNew(string text)
        {
            var todo = new TodoModel();
            todo.Created = DateTimeOffset.Now;
            todo.Text = text;
            _idGenerator += 1;
            todo.Id = _idGenerator;
            _todoRepository.AddOrUpdate(_idGenerator, i => todo, (i, model) => todo);
        }
        
        public bool Update(int id, string text)
        {
            if (_todoRepository.TryGetValue(id, out var todo))
            {
                todo.Text = text;
                todo.Updated = DateTimeOffset.Now;
                return true;
            }
            return false;
        }
        
        public bool Delete(int id)
        {
            if (_todoRepository.TryRemove(id, out var todo))
            {
                return true;
            }
            return false;
        }
    }
}
