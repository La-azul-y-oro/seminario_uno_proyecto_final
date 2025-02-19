using AutoMapper;
using api.Models;

namespace api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
