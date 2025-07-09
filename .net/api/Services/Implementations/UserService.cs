using System.Linq;
using api.Context;
using api.Dto;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserMapper _userMapper;

        public UserService(ApplicationDbContext context, UserMapper userMapper)
        {
            _context = context;
            _userMapper = userMapper;
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

        public List<Client> FindClientsByFunctionalUnitId(int functionalUnitId)
        {
            var users = _context.User
                .Where(u => u.FunctionalUnits.Any(fu => fu.Id == functionalUnitId))
                .Where(u => u.Role == Role.CLIENT && u.Active == true)
                .ToList();

            return users.Select(user => _userMapper.GetClient(user)).ToList();
        }

        public List<Client> GetAllClients()
        {
            return _context.User
                .Where(u => u.Active && u.Role == Role.CLIENT)
                .Select(u => _userMapper.GetClient(u))
                .ToList();
        }

    }
}
