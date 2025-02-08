using api.Context;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class SupplierService : IGenericService<Supplier, long>
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Supplier.Where(c => c.Active).ToList();
        }

        public Supplier GetById(long id)
        {
            var supplier = _context.Supplier.Find(id);
            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            return supplier;
        }

        public void Create(Supplier entity)
        {
            _context.Supplier.Add(entity);
            _context.SaveChanges();
        }

        public void Update(long id, Supplier entity)
        {
            var supplier = _context.Supplier.Find(id);
            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            supplier.Name = entity.Name;
            supplier.Phone = entity.Phone;
            supplier.Email = entity.Email;

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var supplier = _context.Supplier.Find(id);
            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            supplier.Active = false;
            _context.SaveChanges();
        }
    }
}

