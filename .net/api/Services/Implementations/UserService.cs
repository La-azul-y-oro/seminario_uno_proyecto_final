using api.Context;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;


        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.User.Where(c => c.Active).ToList();
            return users;
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

        public void Update(User user)
        {
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

        public User GetByEmail(string email)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == email);
            if (user == null || !user.Active)
            {
                return null;
            }
            return user;
        }


        public User GetByResetToken(string resetToken)
        {
            var user = _context.User.FirstOrDefault(u => u.ResetPasswordToken == resetToken);
            if (user == null || !user.Active)
            {
                throw new KeyNotFoundException();
            }
            return user;
        }

        //public async Task<User?> GetByResetTokenAsync(string token)
        //{
        //    return await _context.User.FirstOrDefaultAsync(u => u.ResetPasswordToken == token);
        //}

    }
}
