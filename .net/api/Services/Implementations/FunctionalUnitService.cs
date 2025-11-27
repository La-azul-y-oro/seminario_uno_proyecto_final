using api.Context;
using api.Dto;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using System.Linq;

namespace api.Services.Implementations
{
    public class FunctionalUnitService : IFunctionalUnitService
    {
        private readonly ApplicationDbContext _context;
        private readonly FunctionalUnitMapper _functionalUnitMapper;

        public FunctionalUnitService(ApplicationDbContext context, FunctionalUnitMapper functionalUnitMapper)
        {
            _context = context;
            _functionalUnitMapper = functionalUnitMapper;
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
            Update(id, entity, true);         
        }

        public void Create(FunctionalUnit entity)
        {
            Create(entity, true);
        }

        public void Delete(int id)
        {
            Delete(id, true);
        }

        public async Task ProcessBatchOperations(FunctionalUnitBatchRequest request)
        {
            if (request == null)
            {
                throw new BadHttpRequestException("Data cannot be null");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                ProcessDeleteOperations(request.Delete, request.ConsortiumId);

                ProcessUpdateOperations(request.Update, request.ConsortiumId);

                ProcessCreateOperations(request.Create, request.ConsortiumId);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Batch operation failed: " + ex.Message);
            }
        }

        private void ProcessDeleteOperations(List<int> deleteIds, int consortiumId)
        {
            foreach (var id in deleteIds)
            {
                var existingUnit = GetById(id);
                if (existingUnit == null)
                {
                    throw new KeyNotFoundException($"Functional unit with ID {id} not found");
                }

                if (existingUnit.ConsortiumId != consortiumId)
                {
                    throw new UnauthorizedAccessException($"Functional unit with ID {id} does not belong to consortium {consortiumId}");
                }

                Delete(id, false);
            }
        }

        private void ProcessUpdateOperations(List<FunctionalUnitRequest> updateRequests, int consortiumId)
        {
            foreach (var updateRequest in updateRequests)
            {
                var existingUnit = GetById((int)updateRequest.Id);
                if (existingUnit == null)
                {
                    throw new KeyNotFoundException($"Functional unit with ID {updateRequest.Id} not found");
                }

                if (existingUnit.ConsortiumId != consortiumId)
                {
                    throw new UnauthorizedAccessException($"Functional unit with ID {updateRequest.Id} does not belong to consortium {consortiumId}");
                }

                var functionalUnit = new FunctionalUnit
                {
                    Name = updateRequest.Name,
                    Balance = updateRequest.Balance,
                    Factor = updateRequest.Factor,
                    ConsortiumId = consortiumId
                };

                Update((int)updateRequest.Id, functionalUnit, false);
            }
        }

        private void ProcessCreateOperations(List<FunctionalUnitRequest> createRequests, int consortiumId)
        {
            foreach (var createRequest in createRequests)
            {
                var functionalUnit = new FunctionalUnit
                {
                    Name = createRequest.Name,
                    Balance = createRequest.Balance,
                    Factor = createRequest.Factor,
                    ConsortiumId = createRequest.ConsortiumId
                };

                Create(functionalUnit, false);
            }
        }
        public void Update(int id, FunctionalUnit entity, bool saveChanges = true)
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

            if(saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Create(FunctionalUnit entity, bool saveChanges = true)
        {
            _context.FunctionalUnit.Add(entity);
            if (saveChanges) { 
                _context.SaveChanges(); 
            }
        }

        public void Delete(int id, bool saveChanges = true)
        {
            var functionalUnit = _context.FunctionalUnit.Find(id);

            if (functionalUnit == null || !functionalUnit.Active)
            {
                throw new KeyNotFoundException("User not found");
            }

            functionalUnit.Active = false;
            if(saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public List<FunctionalUnitResponse> FindByConsortiumId(int consortiumId)
        {
            return _context.FunctionalUnit
                .Include(fu => fu.UserFunctionalUnits)
                    .ThenInclude(ufu => ufu.User)
                .Where(fu => fu.ConsortiumId == consortiumId && fu.Active)
                .ToList()
                .Select(u => _functionalUnitMapper.GetFunctionalUnitResponse(u))
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

        public void UpdateClientsToFunctionalUnit(int FunctionalId, List<ClientFunctionalUnitDto> clients)
        {
            var functionalUnit = _context.FunctionalUnit
                .Include(fu => fu.UserFunctionalUnits)
                .FirstOrDefault(fu => fu.Id == FunctionalId && fu.Active);

            if (functionalUnit == null)
            {
                throw new ArgumentException($"Functional unit with ID {FunctionalId} not found or inactive");
            }

            functionalUnit.UserFunctionalUnits.Clear();

            if (clients != null && clients.Any())
            {
                var clientIds = clients.Select(c => c.ClientId).ToList();

                var users = _context.User
                    .Where(u => clientIds.Contains(u.Id) && u.Active)
                    .ToList();

                if (users.Count != clientIds.Count)
                {
                    var foundIds = users.Select(u => u.Id).ToList();
                    var missingIds = clientIds.Except(foundIds).ToList();
                    throw new ArgumentException($"Users not found or inactive: {string.Join(", ", missingIds)}");
                }

                foreach (var client in clients)
                {
                    var userFunctionalUnit = new UserFunctionalUnit
                    {
                        UserId = client.ClientId,
                        FunctionalUnitId = FunctionalId,
                        OccupantType = client.OccupantType
                    };
                    functionalUnit.UserFunctionalUnits.Add(userFunctionalUnit);
                }
            }

            _context.SaveChanges();
        }

        public List<ClientFunctionalUnit> GetByClientId(int ClientId)
        {
            var functionalUnits = _context.FunctionalUnit
                .Include(fu => fu.Consortium)
                .Include(fu => fu.UserFunctionalUnits)
                .Where(fu => fu.UserFunctionalUnits.Any(ufu => ufu.UserId == ClientId && ufu.User.Active))
                .Where(fu => fu.Active)
                .ToList();

            var result = functionalUnits.Select(fu =>
            {
                var relation = fu.UserFunctionalUnits.First(ufu => ufu.UserId == ClientId);

                return new ClientFunctionalUnit
                {
                    Id = fu.Id,
                    Name = fu.Name,
                    Balance = fu.Balance,
                    Factor = fu.Factor,
                    Consortium = fu.Consortium.Name,
                    ConsortiumAddress = fu.Consortium.Address,
                    ConsortiumId = fu.Consortium.Id,
                    OccupantType = relation.OccupantType,
                    Liquidations = GetLiquidationsForFunctionalUnit(fu.Id, fu.ConsortiumId)
                };
            }).ToList();

            return result;
        }

        private List<LiquidationDTO> GetLiquidationsForFunctionalUnit(int functionalUnitId, int consortiumId)
        {
            var liquidations = _context.Liquidation
                .Where(l => l.ConsortiumId == consortiumId)
                .Select(l => new LiquidationDTO
                {
                    Id = l.Id,
                    Period = l.Period,
                    ExpirationDate = l.ExpirationDate
                })
                .ToList();

            return liquidations;
        }
    }
}
