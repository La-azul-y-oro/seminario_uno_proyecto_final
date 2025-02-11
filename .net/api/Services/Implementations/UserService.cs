using api.Context;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            return _context.User.Where(c => c.active).ToList();
        }

        public User GetById(int id)
        {
            var user = _context.User.Find(id);
            if(user == null || !user.active){ 
                throw new KeyNotFoundException();
            }

            return user;
        }

        public void Update(int id, User entity)
        {
            var user = _context.User.Find(id);

            if(user == null || !user.active){
                throw new KeyNotFoundException("User not found");
            }

            user.name = entity.name;
            user.lastName = entity.lastName;
            user.email = entity.email;
            user.password = entity.password;
            user.telephoneNumber = entity.telephoneNumber;

            _context.SaveChanges();
        }

        public void Create(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.User.Find(id);

            if(user == null || !user.active)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.active = false;
            _context.SaveChanges();
        }

    }
}
