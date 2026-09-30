using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoBe.Entities;

namespace TodoBe.Contexts;

public class TodoDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Todo> Todos { get; set; }
    
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {}
}