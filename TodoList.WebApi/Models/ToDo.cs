namespace TodoList.WebApi.Models;

public class ToDo
{
    public long Id { get; set; }

    public string Title { get; set; } = String.Empty;

    public string Definition { get; set; } = String.Empty;

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public long? UserId { get; set; }
    public virtual User User { get; set; }

    public ToDo()
    {
        User = new User();
    }
}
