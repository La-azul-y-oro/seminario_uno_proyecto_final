using api.Context;
using api.Models;
using api.Services.Interfaces;
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
            return _context.Movement
                .Include(m => m.Supplier)
                .Include(m => m.Consortium)
                .Include(m => m.Concept)
                .Include(m => m.FunctionalUnit)
                .Where(m => m.Active)
                .ToList();
        }

        public Movement GetById(int id)
        {
            var movement = _context.Movement
                    .Include(m => m.Supplier)
                    .Include(m => m.Consortium)
                    .Include(m => m.Concept)
                    .Include(m => m.FunctionalUnit)
                    .FirstOrDefault(m => m.Id == id && m.Active);

            if (movement == null)
            {
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

            if (movement.Type.Equals(MovementType.EGRESO))
            {
                validateLiquidationPeriod(movement);
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

        public Movement CreateAndReturn(Movement entity)
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

            return _context.Movement
                .Include(m => m.Supplier)
                .Include(m => m.Consortium)
                .Include(m => m.Concept)
                .Include(m => m.FunctionalUnit)
                .First(m => m.Id == entity.Id);
        }

        public void Create(Movement entity) { }

        public void Delete(int id)
        {
            var movement = _context.Movement.Find(id);

            if (movement == null || !movement.Active)
            {
                throw new KeyNotFoundException("Movement not found");
            }
            if (movement.Type.Equals(MovementType.EGRESO))
            {
                validateLiquidationPeriod(movement);
            }
            if (movement.Type.Equals(MovementType.INGRESO))
            {
                var copyMovement = movement.Clone();
                copyMovement.Amount = (-1) * copyMovement.Amount;

                updateFunctionalUnitBalance(copyMovement);
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
                throw new InvalidOperationException("Cannot perform an operation for a period that has already closed.");
            }
        }

        private void updateFunctionalUnitBalance(Movement entity)
        {
            if (entity.FunctionalUnitId != null) {
                _functionalUnitService.UpdateBalance((int) entity.FunctionalUnitId, entity.Amount);
            }
        }
    }
}