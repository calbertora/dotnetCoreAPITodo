using Microsoft.EntityFrameworkCore;

namespace TestApi
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {}

        public DbSet<Item> TodoItems {get;set;}
    }
}