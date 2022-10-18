using System.ComponentModel.DataAnnotations;
using TodoList.WebApi.Models;

namespace TodoList.WebApi.ViewModels.Todos;

public class TodoCreateViewModel
{
    [Required, MaxLength(50)]
    public string Title { get; set; } = String.Empty;

    public string Definition { get; set; } = String.Empty;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime FromDate { get; set; }

    [Required]
    public DateTime ToDate { get; set; }

    public static implicit operator ToDo(TodoCreateViewModel todoCreateViewModel)
    {
        return new ToDo()
        {
            Title = todoCreateViewModel.Title,
            Definition = todoCreateViewModel.Definition,
            FromDate =  todoCreateViewModel.FromDate.ToUniversalTime(),
            ToDate = todoCreateViewModel.ToDate.ToUniversalTime()
        };
    }
}
