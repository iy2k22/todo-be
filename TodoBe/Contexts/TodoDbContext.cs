using Microsoft.EntityFrameworkCore;
using TodoBe.Entities;

namespace TodoBe.Contexts;

public class TodoDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {}
}