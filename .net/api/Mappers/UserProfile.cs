using AutoMapper;
using api.Models;
using api.Dto;

namespace api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<User, Client>();
        }
    }
}
