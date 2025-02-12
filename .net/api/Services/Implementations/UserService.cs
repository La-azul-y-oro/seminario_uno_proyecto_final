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
            return _context.User.Where(c => c.Active).ToList();
        }

        public User GetById(int id)
        {
            var user = _context.User.Find(id);
            if(user == null || !user.Active){ 
                throw new KeyNotFoundException();
            }

            return user;
        }

        public void Update(int id, User entity)
        {
            var user = _context.User.Find(id);

            if(user == null || !user.Active){
                throw new KeyNotFoundException("User not found");
            }

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Phone = entity.Phone;

            _context.SaveChanges();
        }

        public void Create(User entity)
        {
            Console.Write(entity);
            _context.User.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.User.Find(id);

            if(user == null || !user.Active)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.Active = false;
            _context.SaveChanges();
        }

    }
}
