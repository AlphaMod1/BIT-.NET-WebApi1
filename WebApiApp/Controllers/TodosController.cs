using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly DataContext _context;

        public TodosController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }

        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            var returnable = _context.Todos.FirstOrDefault(i => i.Id == id);

            if (returnable == null)
            {
                throw new KeyNotFoundException();
            }

            return returnable;
        }

        [HttpPost]
        public void Create(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update(Todo todo, int id)
        {
            _context.Update(todo);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var todoItemDel = _context.Todos.FirstOrDefault(i => i.Id == id);

            if (todoItemDel != null)
            {
                _context.Todos.Remove(todoItemDel);
                _context.SaveChanges();
            }
            
        }
    }
    

}
