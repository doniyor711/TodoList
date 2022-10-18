using TodoList.WebApi.Utils;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params);

        Task<(int statusCode, UserViewModel todo, string message)> GetAsync(long id);

        Task<(int statusCode, string message)> CreateAsync(UserCreateViewModel todoCreareViewModel);

        Task<(int statusCode, string message)> UpdateAsync(long id, UserCreateViewModel todoCreareViewModel);

        Task<(int statusCode, string message)> DeleteAsync(long id);
    }
}
