using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services
{
    /// <summary>
    /// Todo Service allows creating reading updating & deleting Todos.
    /// </summary>
    public interface ITodoService
    {
        // notice how implementation details are hidden in interfaces
        // this interface could be implemented with file storage, or mysql storage...

        /// <summary>
        /// Lists all Todo items.
        /// </summary>
        List<TodoModel> GetAll();

        /// <summary>
        /// Returns a Todo by Id
        /// </summary>
        TodoModel GetById(int id);

        /// <summary>
        /// Create a new todo, should automatically generate id and timestamp.
        /// </summary>
        void AddNew(string text);

        /// <summary>
        /// Update todo, should automaticaly generates update timestamp.
        /// </summary>
        bool Update(int id, string text);

        /// <summary>
        /// DANGER: forever delets todo, might want to prompt the user before doing so.
        /// </summary>
        bool Delete(int id);
    }
}
