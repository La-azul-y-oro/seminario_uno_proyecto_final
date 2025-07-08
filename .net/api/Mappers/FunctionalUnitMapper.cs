using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class FunctionalUnitMapper
    {
        public FunctionalUnitResponse GetFunctionalUnitResponse(FunctionalUnit functionalUnit)
        {
            return new FunctionalUnitResponse
            {
                Id = functionalUnit.Id,
                Name = functionalUnit.Name,
                Balance = functionalUnit.Balance,
                Factor = functionalUnit.Factor
            };
        }
    }
}
