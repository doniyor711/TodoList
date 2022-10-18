using Microsoft.AspNetCore.Mvc;
using Serilog;
using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Models;
using TodoList.WebApi.Utils;
using TodoList.WebApi.ViewModels.Todos;

namespace TodoList.WebApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;
    public TodoService(ITodoRepository repository)
    {
        this._repository = repository;
    }

    public async Task<(int statusCode, string message)> CreateAsync(TodoCreateViewModel todoCreareViewModel)
    {
        var todo = (ToDo)todoCreareViewModel;
        await _repository.CreateAsync(todo);
        return (statusCode: 200, message: "");
        Log.Warning("");    
    }

    public async Task<(int statusCode, string message)> DeleteAsync(long id)
    {
        var todo = await _repository.GetAsync(id);
        if (todo is null) return (statusCode: 404, message: "Todo not found");
        else
        {
            await _repository.DeleteAsync(id);
            return (statusCode: 200, message: "");
        }
    }

    public async Task<IEnumerable<ToDoViewModel>> GetAllAsync(PaginationParams @params)
    {
        var todos = (await _repository.GetAllAsync()).Skip(@params.GetSkipCount()).Take(@params.PageSize);
        var todoviewmodels = new List<ToDoViewModel>();
        foreach (var todo in todos)
        {
            var todoviewmodel = (ToDoViewModel)todo;
            todoviewmodels.Add(todoviewmodel);
        }
        return todoviewmodels;
    }

    public async Task<(int statusCode, ToDoViewModel todo, string message)> GetAsync(long id)
    {
        var todo = await _repository.GetAsync(id);
        if (todo is null) return (statusCode: 404, todo : (ToDoViewModel)new ToDo(), message: "Todo not found");
        else return (statusCode: 200, todo: todo, message: "");
    }

    public async Task<(int statusCode, string message)> UpdateAsync(long id, TodoCreateViewModel todoCreateViewModel)
    {
        var todo = await _repository.GetAsync(id);
        if (todo is null) return (statusCode: 404, message: "Todo not found");
        else
        {
            var todoNew = (ToDo) todoCreateViewModel;
            await _repository.UpdateAsync(id, todoNew);
            return (statusCode: 200, message: "");
        }
    }
}
