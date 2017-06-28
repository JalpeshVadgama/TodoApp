using System.Collections.Generic;
using TodoApp.Models;
using System;

namespace TodoApp.Services
{
    public interface ITodoService : IDisposable
    {
        bool Add(TodoItem item);
        TodoItem Get(int todoItemId);
        List<TodoItem> GetAll();
    }
}