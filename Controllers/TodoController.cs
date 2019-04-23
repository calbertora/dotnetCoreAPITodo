using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController: ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0) {
                _context.TodoItems.Add(new Item {
                    ItemName = "Test 1"
                });
                _context.TodoItems.Add(new Item {
                    ItemName = "Test 2"
                });
                _context.TodoItems.Add(new Item {
                    ItemName = "Test 3"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }
    }
}