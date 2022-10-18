using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Interfaces.Services
{
    public interface IAccountService
    {
        Task<(int statusCode, string message)> RegistrAsync(UserCreateViewModel userCreateViewModel);

        Task<(int statusCode, string token, string message)> LoginAsync();
    }
}
