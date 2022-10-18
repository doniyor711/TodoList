using Microsoft.EntityFrameworkCore;
using TodoList.WebApi.Data;
using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Models;

namespace TodoList.WebApi.Repositories;
#nullable disable
public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _dbo;

    public TodoRepository(AppDbContext appDbContext)
    {
        _dbo = appDbContext;
    }
    public async Task CreateAsync(ToDo toDo)
    {
        await _dbo.ToDos.AddAsync(toDo);
        await _dbo.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var todo = await _dbo.ToDos.FindAsync(id);
        if(todo is not null)
        {
            _dbo.ToDos.Remove(todo);
            await _dbo.SaveChangesAsync();
        }
    }

    public async Task<IQueryable<ToDo>> GetAllAsync()
    {
        return _dbo.ToDos.Where(x=>true);
    }

    public async Task<ToDo> GetAsync(long id)
    {
        var todo = await _dbo.ToDos.FindAsync(id);
        return todo;
    }

    public async Task<ToDo> UpdateAsync(long id, ToDo toDo)
    {
        toDo.Id = id;
        _dbo.ToDos.Update(toDo);
        await _dbo.SaveChangesAsync();
        return toDo;
    }
}
