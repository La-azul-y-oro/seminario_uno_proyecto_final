using api.Context;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class FunctionalUnitService : IFunctionalUnitService
    {
        private readonly ApplicationDbContext _context;

        public FunctionalUnitService(ApplicationDbContext context)
        {
            _context = context;
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

        public List<FunctionalUnit> FindByConsortiumId(int consortiumId)
        {
            return _context.FunctionalUnit
                .Where(fu => fu.ConsortiumId == consortiumId && fu.Active)
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
    }
}
