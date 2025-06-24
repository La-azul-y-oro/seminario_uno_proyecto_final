using System.Security.Claims;
using api.Context;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class LiquidationService : ILiquidationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMovementService _movementService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public LiquidationService(ApplicationDbContext context, IMovementService movementService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _context = context;
            _movementService = movementService;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public void GenerateLiquidation(int consortiumId, int month, int year, DateTime expirationDate) {
            ValidateDate(month, year, expirationDate);
            if (LiquidationExists(consortiumId, month, year)) return;

            var movements = _movementService.GetByConsortiumAndMonthAndYear(consortiumId, month, year);
            var expenses = movements.Where(m => m.Type == MovementType.EGRESO).ToList();
            var sumExpenses = expenses.Sum(m => m.Amount);

            var liquidation = new Liquidation
            {
                ConsortiumId = consortiumId,
                Period = $"{year}-{month:D2}",
                GenerateAt = DateTime.Now,
                ExpirationDate = expirationDate,
                Amount = sumExpenses,
                GenerateBy = GetUserId()
            };

            _context.Liquidation.Add(liquidation);
            _context.SaveChanges();
        }

        public IEnumerable<Liquidation> GetAllByConsortiumId(int consortiumId)
        {
            return _context.Liquidation.Where(m => m.ConsortiumId == consortiumId).ToList();
        }

        public Liquidation GetByPeriod(string period)
        {
            var liquidation = _context.Liquidation.FirstOrDefault(l => l.Period == period);

            if (liquidation == null)
                throw new KeyNotFoundException("Liquidation not found");

            return liquidation;
        }

        private static void ValidateDate(int month, int year, DateTime expirationDate) {
            var now = DateTime.Now;

            if (year > now.Year || (year == now.Year && month > now.Month))
            {
                throw new InvalidOperationException("A settlement cannot be generated for a future period.");
            }

            if (expirationDate <= now)
            {
                throw new InvalidOperationException("The expiration date must be after the current date.");
            }
        }

        private bool LiquidationExists(int consortiumId, int month, int year)
        {
            var period = $"{year}-{month:D2}";

            return _context.Liquidation
                .Any(l => l.ConsortiumId == consortiumId && l.Period == period);
        }

        private int GetUserId() {
            var user = _httpContextAccessor.HttpContext?.User;
            var emailClaim = user?.FindFirst(ClaimTypes.NameIdentifier);

            if (emailClaim == null)
            {
                throw new UnauthorizedAccessException("The authenticated user's email could not be obtained.");
            }

            var userEntity = _userService.GetByEmail(emailClaim.Value);

            if (userEntity == null)
            {
                throw new UnauthorizedAccessException("The user is not registered.");
            }

            return userEntity.Id;
        }
    }
}
