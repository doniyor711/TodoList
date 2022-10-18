using TodoList.WebApi.Utils;
using TodoList.WebApi.ViewModels.Todos;

namespace TodoList.WebApi.Interfaces.Services;

public interface ITodoService
{
    Task<IEnumerable<ToDoViewModel>> GetAllAsync(PaginationParams @params);

    Task<(int statusCode, ToDoViewModel todo, string message)> GetAsync(long id);

    Task<(int statusCode, string message)> CreateAsync(TodoCreateViewModel todoCreareViewModel);

    Task<(int statusCode, string message)> UpdateAsync(long id, TodoCreateViewModel todoCreareViewModel);

    Task<(int statusCode, string message)> DeleteAsync(long id);
}
    