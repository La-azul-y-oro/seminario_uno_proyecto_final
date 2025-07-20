using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class MovementMapper
    {
        private readonly IMapper _mapper;

        public MovementMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MovementDTO GetMovementDTO(Movement movement)
        {
            return _mapper.Map<MovementDTO>(movement);
        }

        public Movement GetMovement(MovementDTO movementDTO)
        {
            return _mapper.Map<Movement>(movementDTO);
        }
    }
}
