using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TodoTask> TodoTasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TodoList>().HasData(
        new TodoList { Id = 1, Name = "All Tasks", DisplayOrder = 1 },
        new TodoList { Id = 2, Name = "Important", DisplayOrder = 2 }
      );

      modelBuilder.Entity<TodoTask>().HasData(
        new TodoTask { Id = 1, Name = "Fix air-con", TodoListId = 1},
        new TodoTask { Id = 2, Name = "Make restaurant reservation", TodoListId = 2}
      );
    }
  }
}