using api.Dto;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Mappers
{
    public class FunctionalUnitMapper
    {
        private readonly IUserService _userService;

        public FunctionalUnitMapper(IUserService userService)
        {
            _userService = userService;
        }
        public FunctionalUnitResponse GetFunctionalUnitResponse(FunctionalUnit functionalUnit)
        {
            return new FunctionalUnitResponse
            {
                Id = functionalUnit.Id,
                Name = functionalUnit.Name,
                Balance = functionalUnit.Balance,
                Factor = functionalUnit.Factor,
                Clients = _userService.FindClientsByFunctionalUnitId(functionalUnit.Id)
            };
        }
    }
}
