using api.Context;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations{
    public class MovementService : IMovementService {

        private readonly ApplicationDbContext _context;

        public MovementService(ApplicationDbContext context){
            _context = context;
        }

        public IEnumerable<Movement> GetAll()
        {
            return _context.Movement.Where(m => m.Active).ToList();
        }

        public Movement GetById(int id)
        {
            var movement = _context.Movement.Find(id);

            if(movement == null || !movement.Active){
                throw new KeyNotFoundException();
            }

            return movement;
        }

        public void Update(int id, Movement entity)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null || !movement.Active)
            {
                throw new KeyNotFoundException();
            }

            movement.Date = entity.Date;
            movement.Amount = entity.Amount;
            movement.Type = entity.Type;
            movement.Receipt = entity.Receipt;
            movement.ConsortiumId = entity.ConsortiumId;
            movement.SupplierId = entity.SupplierId;
            movement.ConceptId = entity.ConceptId;
            movement.FunctionalUnitId = entity.FunctionalUnitId;
            movement.Comment = entity.Comment;

            _context.SaveChanges();
        }

        public void Create(Movement entity)
        {
            _context.Movement.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null || !movement.Active)
            {
                throw new KeyNotFoundException("User not found");
            }

            movement.Active = false;
            _context.SaveChanges();
        }

        public List<Movement> GetByConsortiumAndMonthAndYear(int consortiumId,int month, int year)
        {
            return _context.Movement
                .Include(m => m.Concept)
                .Include(m => m.Supplier)
                .Where(m =>
                    m.ConsortiumId == consortiumId &&
                    m.Date.Month == month &&
                    m.Date.Year == year &&
                    m.Active)
                .ToList();
        }

        public List<Movement> GetByConsortiumAndYear(int consortiumId, int year)
        {
            return _context.Movement
                .Include(m => m.Concept)
                .Include(m => m.Supplier)
                .Where(m =>
                    m.ConsortiumId == consortiumId &&
                    m.Date.Year == year &&
                    m.Active)
                .ToList();
        }
    }
}