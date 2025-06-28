using api.Context;
using api.Models;
using api.Services.Interfaces;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations{
    public class MovementService : IMovementService {

        private readonly ApplicationDbContext _context;
        private readonly IFunctionalUnitService _functionalUnitService;
        private readonly IServiceProvider _serviceProvider;

        public MovementService(ApplicationDbContext context, IFunctionalUnitService functionalUnitService, IServiceProvider serviceProvider)
        {
            _context = context;
            _functionalUnitService = functionalUnitService;
            _serviceProvider = serviceProvider;
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
            if (entity.Type.Equals(MovementType.EGRESO)){
                validateLiquidationPeriod(entity);
            }

            _context.Movement.Add(entity);
            _context.SaveChanges();

            if (entity.Type.Equals(MovementType.INGRESO))
            {
                updateFunctionalUnitBalance(entity);
            }
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

        private void validateLiquidationPeriod(Movement entity)
        {
            var liquidationService = _serviceProvider.GetRequiredService<ILiquidationService>();

            var liquidation = liquidationService.GetByPeriodAndConsortiumId($"{entity.Date.Year}-{entity.Date.Month:D2}", entity.ConsortiumId);

            if (liquidation != null) {
                throw new InvalidOperationException("Cannot enter an expense for a period that has already closed.");
            }
        }

        private void updateFunctionalUnitBalance(Movement entity)
        {
            if (entity.FunctionalUnitId != null) {
                _functionalUnitService.UpdateBalance(entity.Id, entity.Amount);
            }
        }
    }
}