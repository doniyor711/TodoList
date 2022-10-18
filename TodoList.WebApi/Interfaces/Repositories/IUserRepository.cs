using TodoList.WebApi.Models;

namespace TodoList.WebApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);

        Task<IQueryable<User>> GetAllAsync();

        Task<User> GetAsync(long id);

        Task<User> UpdateAsync(long id, User user);

        Task DeleteAsync(long id);
    }
}
