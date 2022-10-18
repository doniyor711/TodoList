using System.Text.Json.Serialization;

namespace TodoList.WebApi.Utils;

public class PaginationParams
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int GetSkipCount() => (PageIndex - 1) * PageSize;
}
