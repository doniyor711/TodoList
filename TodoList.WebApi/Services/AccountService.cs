using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Models;
using TodoList.WebApi.Security;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        public AccountService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public Task<(int statusCode, string token, string message)> LoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<(int statusCode, string message)> RegistrAsync(UserCreateViewModel userCreateViewModel)
        {
            var user = (User) userCreateViewModel;
            var hasherResult = PasswordHasher.Hash(userCreateViewModel.Password);
            user.Salt = hasherResult.Salt;
            user.PasswordHash = hasherResult.Hash;
            await _repository.CreateAsync(user);
            return (statusCode: 200, message: "");
        }
    }
}
