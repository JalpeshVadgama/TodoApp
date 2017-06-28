using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public bool Add(TodoItem item)
        {
            try
            {
                _context.TodoItems.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //Code to write exception
                return false;
            }
            return true;
        }

        public List<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem Get(int todoItemId)
        {
            return _context.TodoItems.FirstOrDefault(t => t.Id == todoItemId);
        }

        #region Disposable methods
        /// <summary>
        /// dispose method to dispose all the resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method based to dispose resources based on disposing flag.
        /// </summary>
        /// <param name="disposing">A boolean flag based on it resources will be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        #endregion

    }
}
