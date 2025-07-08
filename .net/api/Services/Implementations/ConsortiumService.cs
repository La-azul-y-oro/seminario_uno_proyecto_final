using api.Context;
using api.Dto;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class ConsortiumService : IConsortiumService
    {
        private readonly ApplicationDbContext _context;
        private readonly ConsortiumMapper _consortiumMapper;
        private readonly FunctionalUnitMapper _functionalUnitMapper;

        public ConsortiumService(ApplicationDbContext context, ConsortiumMapper consortiumMapper, FunctionalUnitMapper functionalUnitMapper)
        {
            _context = context;
            _consortiumMapper = consortiumMapper;
            _functionalUnitMapper = functionalUnitMapper;
        }

        public IEnumerable<ConsortiumResponse> FindAll() {
            var consortiums = GetAll();

            return consortiums.Select(c => _consortiumMapper.GetConsortiumResponse(c)).ToList();
        }


        public IEnumerable<Consortium> GetAll()
        {   
            return _context.Consortium
                .Where(c => c.Active)
                .ToList();        
        }

        public Consortium GetById(int id)
        {
            var consortium = _context.Consortium.Find(id);

            if (consortium == null || !consortium.Active)
                throw new KeyNotFoundException("Consortium not found");

            return consortium;
        }

        public void Create(Consortium entity)
        {
            _context.Consortium.Add(entity);
            _context.SaveChanges();
        }

        public void Update(int id, Consortium entity)
        {
            var consortium = _context.Consortium.Find(id);
            if (consortium == null || !consortium.Active)
                throw new KeyNotFoundException("Consortium not found");

            consortium.Name = entity.Name;
            consortium.Address = entity.Address;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var consortium = _context.Consortium.Find(id);
            if (consortium == null || !consortium.Active)
                throw new KeyNotFoundException("Consortium not found");

            consortium.Active = false;
            _context.SaveChanges();
        }
    }
}

