using api.Context;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class ConsortiumService : IGenericService<Consortium, int>
    {
        private readonly ApplicationDbContext _context;

        public ConsortiumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Consortium> GetAll()
        {
            return _context.Consortium.Where(c => c.Active).ToList();
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

