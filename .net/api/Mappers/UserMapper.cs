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

        public Client GetClient(User user)
        {
            return _mapper.Map<Client>(user);
        }

        public Client GetClient(User user, OccupantType occupantType)
        {
            var client = _mapper.Map<Client>(user);
            client.OccupantType = occupantType;
            return client;
        }
    }
}
