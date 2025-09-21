using api.Context;
using api.Dto;
using api.Models;
using api.Services.Interfaces;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConceptService _conceptService;

        public SupplierService(ApplicationDbContext context, IConceptService conceptService)
        {
            _context = context;
            _conceptService = conceptService;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Supplier
                .Include(s => s.Concepts.Where(c => c.Active))
                .Where(s => s.Active)
                .ToList();
        }

        public Supplier GetById(int id)
        {
            var supplier = _context.Supplier
                .Include(s => s.Concepts.Where(c => c.Active))
                .FirstOrDefault(s => s.Id == id && s.Active);

            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            return supplier;
        }

        public Supplier Create(SupplierRequestDTO supplierDto)
        {
            var supplier = new Supplier
            {
                Cuit = supplierDto.Cuit,
                Name = supplierDto.Name,
                Phone = supplierDto.Phone,
                Email = supplierDto.Email
            };

            if (supplierDto.Concepts.Any())
            {
                supplier.Concepts = _conceptService.GetByIds(supplierDto.Concepts);
            }

            Create(supplier);
            return supplier;
        }

        public void Create(Supplier entity)
        {
            _context.Supplier.Add(entity);
            _context.SaveChanges();
        }


        public void Update(int id, SupplierRequestDTO supplierDto)
        {
            var supplier = _context.Supplier
                .Include(s => s.Concepts)
                .FirstOrDefault(s => s.Id == id);

            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            supplier.Name = supplierDto.Name;
            supplier.Phone = supplierDto.Phone;
            supplier.Email = supplierDto.Email;

            supplier.Concepts.Clear();

            if (supplierDto.Concepts.Any())
            {
                var concepts = _conceptService.GetByIds(supplierDto.Concepts);
                foreach (var concept in concepts)
                {
                    supplier.Concepts.Add(concept);
                }
            }

            _context.SaveChanges();
        }

        public void Update(int id, Supplier entity)
        {
            var supplier = _context.Supplier.Find(id);
            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            supplier.Name = entity.Name;
            supplier.Phone = entity.Phone;
            supplier.Email = entity.Email;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplier = _context.Supplier.Find(id);
            if (supplier == null || !supplier.Active)
                throw new KeyNotFoundException("Supplier not found");

            supplier.Active = false;
            _context.SaveChanges();
        }
    }
}

