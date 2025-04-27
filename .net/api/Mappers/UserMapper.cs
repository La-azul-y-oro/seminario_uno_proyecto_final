using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class UserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserResponse GetUserResponse(User user)
        {
            return _mapper.Map<UserResponse>(user);
        }

        public User GetUserEntity(UserRequest user)
        {
            return _mapper.Map<User>(user);
        }
    }
}
