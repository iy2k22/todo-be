using Microsoft.EntityFrameworkCore;
using TodoBe.Contexts;
using TodoBe.Entities;

namespace TodoBe.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _dbContext;
    
    public TodoRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Todo>> GetTodos()
    {
        var data = await _dbContext.Todos.OrderBy(x => x.Id).ToListAsync();
        return data;
    }

    public async Task<Todo?> GetTodoById(int id)
    {
        var data = await _dbContext.Todos.FindAsync(id);
        return data;
    }

    public async Task<int> ToggleStatus(int id)
    {
        return await _dbContext.Todos.Where(x => x.Id == id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(t => t.Completed, t => !t.Completed));
    }

    public async Task<int> DeleteTodos()
    {
        return await _dbContext.Todos.Where(x => x.Completed)
            .ExecuteDeleteAsync();
    }

    public async Task<int> CreateTodo(Todo todo)
    {
        await _dbContext.AddAsync(todo);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteTodo(int todoId)
    {
        return await _dbContext.Todos.Where(x => x.Id == todoId).ExecuteDeleteAsync();
    }
}