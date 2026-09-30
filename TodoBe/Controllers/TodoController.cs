using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoBe.Contexts;
using TodoBe.DTOs;
using TodoBe.Entities;
using TodoBe.Repositories;

namespace TodoBe.Controllers;

[ApiController]
[Route("api")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _repository;
    
    public TodoController(ITodoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("GetTodos")]
    public async Task<ActionResult<List<Todo>>> GetTodos(string userId)
    {
        var result = await _repository.GetTodos(userId);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetTodoById/{id}")]
    public async Task<ActionResult<Todo>> GetTodoById(int id)
    {
        try
        {
            var result = await _repository.GetTodoById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorWrapper
            {
                Message = e.Message
            });
        }
    }

    [HttpPatch]
    [Route("ToggleStatus/{id}")]
    public async Task<ActionResult<bool>> ToggleStatus(int id)
    {
        try
        {
            var result = await _repository.ToggleStatus(id);
            return Ok(result == 1);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorWrapper
            {
                Message = e.Message
            });
        }
    }

    [HttpDelete]
    [Route("DeleteTodos")]
    public async Task<ActionResult<int>> DeleteTodos()
    {
        try
        {
            var result = await _repository.DeleteTodos();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorWrapper
            {
                Message = e.Message
            });
        }
    }

    [HttpPost]
    [Route("CreateTodo")]
    public async Task<ActionResult<bool>> CreateTodo([FromBody] Todo todo)
    {
        try
        {
            var result = await _repository.CreateTodo(todo);
            return Ok(result == 1);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorWrapper
            {
                Message = e.Message
            });
        }
    }

    [HttpDelete]
    [Route("DeleteTodoById/{id}")]
    public async Task<ActionResult<bool>> DeleteTodoById(int id)
    {
        try
        {
            var result = await _repository.DeleteTodo(id);
            return Ok(result == 1);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorWrapper
            {
                Message = e.Message
            });
        }
    }
}