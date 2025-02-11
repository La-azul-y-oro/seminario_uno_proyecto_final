using api.Context;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class UserService : IGenericService<User, int>
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
