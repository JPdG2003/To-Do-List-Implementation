using Microsoft.EntityFrameworkCore;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Model
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite();
        }
    }
}
