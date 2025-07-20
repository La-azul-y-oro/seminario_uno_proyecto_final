using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class MovementProfile : Profile
    {
        public MovementProfile()
        {
            // Movement → DTO
            CreateMap<Movement, MovementDTO>()
                .ForMember(dest => dest.ConsortiumName, opt => opt.MapFrom(src => src.Consortium.Name))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null))
                .ForMember(dest => dest.ConceptName, opt => opt.MapFrom(src => src.Concept.Name))
                .ForMember(dest => dest.FunctionalUnitName, opt => opt.MapFrom(src => src.FunctionalUnit != null ? src.FunctionalUnit.Name : null));

            // DTO → Movement
            CreateMap<MovementDTO, Movement>()
                .ForMember(dest => dest.ConsortiumId, opt => opt.MapFrom(src => src.ConsortiumId))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId))
                .ForMember(dest => dest.ConceptId, opt => opt.MapFrom(src => src.ConceptId))
                .ForMember(dest => dest.FunctionalUnitId, opt => opt.MapFrom(src => src.FunctionalUnitId))
                .ForMember(dest => dest.Consortium, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.Concept, opt => opt.Ignore())
                .ForMember(dest => dest.FunctionalUnit, opt => opt.Ignore())
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));
        }
    }
}
