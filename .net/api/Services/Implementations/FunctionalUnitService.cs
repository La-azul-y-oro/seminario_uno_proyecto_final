using api.Context;
using api.Dto;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class FunctionalUnitService : IFunctionalUnitService
    {
        private readonly ApplicationDbContext _context;
        private readonly FunctionalUnitMapper _functionalUnitMapper;

        public FunctionalUnitService(ApplicationDbContext context, FunctionalUnitMapper functionalUnitMapper)
        {
            _context = context;
            _functionalUnitMapper = functionalUnitMapper;
        }

        public IEnumerable<FunctionalUnit> GetAll()
        {
            return _context.FunctionalUnit.Include(fu => fu.Consortium).ToList();

        }

        public FunctionalUnit GetById(int id)
        {
            var functionalUnit = _context.FunctionalUnit
                .Include(fu => fu.Consortium)
                .FirstOrDefault(fu => fu.Id == id);

            if (functionalUnit == null || !functionalUnit.Active){
                throw new KeyNotFoundException();
            }

            return functionalUnit;
        }

        public void Update(int id, FunctionalUnit entity)
        {
            var functionalUnit = _context.FunctionalUnit.Find(id);

            if (functionalUnit == null || !functionalUnit.Active)
            {
                throw new KeyNotFoundException();
            }

            functionalUnit.Name = entity.Name;
            functionalUnit.Balance = entity.Balance;
            functionalUnit.Factor = entity.Factor;
            functionalUnit.ConsortiumId = entity.ConsortiumId;

            _context.SaveChanges();
        }

        public void Create(FunctionalUnit entity)
        {
            _context.FunctionalUnit.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var functionalUnit = _context.FunctionalUnit.Find(id);

            if (functionalUnit == null || !functionalUnit.Active)
            {
                throw new KeyNotFoundException("User not found");
            }

            functionalUnit.Active = false;
            _context.SaveChanges();
        }

        public List<FunctionalUnitResponse> FindByConsortiumId(int consortiumId)
        {
            return _context.FunctionalUnit
                .Where(fu => fu.ConsortiumId == consortiumId && fu.Active)
                .ToList()
                .Select(u => _functionalUnitMapper.GetFunctionalUnitResponse(u))
                .ToList();
        }

        public void UpdateBalance(int id, decimal amount)
        {
            var functionalUnit = _context.FunctionalUnit.Find(id);

            if (functionalUnit == null || !functionalUnit.Active)
            {
                throw new KeyNotFoundException($"Functional Unit with ID {id} not found or inactive.");
            }

            functionalUnit.Balance += amount;
            _context.SaveChanges();
        }

        public void UpdateClientsToFunctionalUnit(int FunctionalId, List<int> ClientsIds)
        {
            var functionalUnit = _context.FunctionalUnit
                .Include(fu => fu.Users)
                .FirstOrDefault(fu => fu.Id == FunctionalId && fu.Active);

            if (functionalUnit == null)
            {
                throw new ArgumentException($"Functional unit with ID {FunctionalId} not found or inactive");
            }

            functionalUnit.Users.Clear();

            if (ClientsIds != null && ClientsIds.Any())
            {
                var users = _context.User
                    .Where(u => ClientsIds.Contains(u.Id) && u.Active)
                    .ToList();

                if (users.Count != ClientsIds.Count)
                {
                    var foundIds = users.Select(u => u.Id).ToList();
                    var missingIds = ClientsIds.Except(foundIds).ToList();
                    throw new ArgumentException($"Users not found or inactive: {string.Join(", ", missingIds)}");
                }

                foreach (var user in users)
                {
                    functionalUnit.Users.Add(user);
                }
            }

            _context.SaveChanges();
        }
    }
}
