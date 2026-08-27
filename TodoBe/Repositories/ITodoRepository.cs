using TodoBe.Entities;

namespace TodoBe.Repositories;

public interface ITodoRepository
{
    public Task<List<Todo>> GetTodos();
    public Task<Todo?> GetTodoById(int id);
    public Task<int> ToggleStatus(int id);
    public Task<int> DeleteTodos();
    public Task<int> CreateTodo(Todo todo);
    public Task<int> DeleteTodo(int id);
}