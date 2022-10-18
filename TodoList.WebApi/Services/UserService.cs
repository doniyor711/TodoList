using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Utils;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Services
{
    public class UserService : IUserService
    {
        public Task<(int statusCode, string message)> CreateAsync(UserCreateViewModel todoCreareViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(int statusCode, string message)> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<(int statusCode, UserViewModel todo, string message)> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<(int statusCode, string message)> UpdateAsync(long id, UserCreateViewModel todoCreareViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
