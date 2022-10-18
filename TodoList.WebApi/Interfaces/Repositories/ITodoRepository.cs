using TodoList.WebApi.Models;

namespace TodoList.WebApi.Interfaces.Repositories;

public interface ITodoRepository
{
    Task CreateAsync(ToDo toDo);

    Task<ToDo> UpdateAsync(long id, ToDo toDo);

    Task DeleteAsync(long id);

    Task<IQueryable<ToDo>> GetAllAsync();

    Task<ToDo> GetAsync(long id);
}
