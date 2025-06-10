using api.Context;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations{
    public class MovementService : IGenericService<Movement, int>{

        private readonly ApplicationDbContext _context;

        public MovementService(ApplicationDbContext context){
            _context = context;
        }

        public IEnumerable<Movement> GetAll()
        {
            return _context.Movement.Where(m => m.active).ToList();
        }

        public Movement GetById(int id)
        {
            var movement = _context.Movement.Find(id);

            if(movement == null || !movement.active){
                throw new KeyNotFoundException();
            }

            return movement;
        }

        public void Update(int id, Movement entity)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null || !movement.active)
            {
                throw new KeyNotFoundException();
            }

            movement.date = entity.date;
            movement.amount = entity.amount;
            movement.type = entity.type;
            movement.receipt = entity.receipt;
            movement.consortiumId = entity.consortiumId;
            movement.supplierCuit = entity.supplierCuit;
            movement.conceptId = entity.conceptId;
            movement.functionalUnitId = entity.functionalUnitId;

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

            if (movement == null || !movement.active)
            {
                throw new KeyNotFoundException("User not found");
            }

            movement.active = false;
            _context.SaveChanges();
        }
    }
}