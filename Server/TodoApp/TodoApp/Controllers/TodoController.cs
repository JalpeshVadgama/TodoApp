using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;
using Microsoft.AspNetCore.Http;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _todoService.GetAll();
        }

        [HttpPost]
        public IActionResult Add([FromBody]TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 _todoService.Add(item);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("Get", new { id = item.Id }, item);
        }

        [HttpGet("{itemId}", Name = "GetTodoItem")]
        public IActionResult GetTodoItem(int itemId)
        {
            TodoItem item = _todoService.Get(itemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

    }
}