using api.Models;

namespace api.Services.Interfaces
{
    public interface IUserService : IGenericService<User, int>
    {
        User GetByEmail(string email);

        void Update(User user);

        User GetByResetToken(String resetToken);
    }
}
