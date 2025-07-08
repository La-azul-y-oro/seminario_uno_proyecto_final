using api.Dto;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Mappers
{
    public class ConsortiumMapper
    {
        private readonly IFunctionalUnitService _functionalUnitService;

        public ConsortiumMapper(IFunctionalUnitService functionalUnitService)
        {
            _functionalUnitService = functionalUnitService;
        }

        public ConsortiumResponse GetConsortiumResponse(Consortium consortium)
        {
            return new ConsortiumResponse
            {
                Id = consortium.Id,
                Name = consortium.Name,
                Address = consortium.Address,
                FunctionalUnits = _functionalUnitService.FindByConsortiumId(consortium.Id)
            };
        }
    }
}
