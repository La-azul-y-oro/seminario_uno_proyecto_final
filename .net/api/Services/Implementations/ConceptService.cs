using api.Context;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class ConceptService : IGenericService<Concept, int>
    {
        private readonly ApplicationDbContext _context;

        public ConceptService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Concept> GetAll()
        {
            return _context.Concept.Where(c => c.Active).ToList();
        }

        public Concept GetById(int id)
        {
            var concept = _context.Concept.Find(id);
            if (concept == null || !concept.Active)
                throw new KeyNotFoundException("Concept not found");

            return concept;
        }

        public void Create(Concept entity)
        {
            _context.Concept.Add(entity);
            _context.SaveChanges();
        }

        public void Update(int id, Concept entity)
        {
            var concept = _context.Concept.Find(id);
            if (concept == null || !concept.Active)
                throw new KeyNotFoundException("Concept not found");

            concept.Name = entity.Name;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var concept = _context.Concept.Find(id);
            if (concept == null || !concept.Active)
                throw new KeyNotFoundException("Concept not found");

            concept.Active = false;
            _context.SaveChanges();
        }
    }
}

