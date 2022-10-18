using TodoList.WebApi.Models;

namespace TodoList.WebApi.ViewModels.Todos
{
    public class ToDoViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string Definition { get; set; } = String.Empty;

        public string FromDate { get; set; } = String.Empty;

        public string ToDate { get; set; } = String.Empty;


        public static implicit operator ToDoViewModel (ToDo toDo)
        {
            return new ToDoViewModel()
            {
                Id = toDo.Id,
                Title = toDo.Title,
                Definition = toDo.Definition,
                FromDate = toDo.FromDate.ToLocalTime().ToString("dd.MM.yyyy HH:mm"),
                ToDate = toDo.ToDate.ToLocalTime().ToString("dd.MM.yyyy HH:mm"),
            };
        }

    }
}
