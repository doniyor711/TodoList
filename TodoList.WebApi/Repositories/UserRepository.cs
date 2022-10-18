using TodoList.WebApi.Data;
using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Models;

namespace TodoList.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbo;
        public UserRepository(AppDbContext appDbContext)
        {
            this._dbo = appDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _dbo.Users.AddAsync(user);
            await _dbo.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(long id)
        {
            var user = await _dbo.Users.FindAsync(id);
            if(user is not null)
            {
                _dbo.Users.Remove(user);
                await _dbo.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return _dbo.Users.Where(x => true);
        }

        public async Task<User> GetAsync(long id)
            => await _dbo.Users.FindAsync(id);

        public async Task<User> UpdateAsync(long id, User user)
        {
            user.Id = id;
            _dbo.Users.Update(user);
            await _dbo.SaveChangesAsync();
            return user;
        }
    }
}
