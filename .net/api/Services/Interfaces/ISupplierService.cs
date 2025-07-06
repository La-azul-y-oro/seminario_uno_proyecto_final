using api.Dto;
using api.Models;

namespace api.Services.Interfaces
{
    public interface ISupplierService : IGenericService<Supplier, int>
    {
        Supplier Create(SupplierRequestDTO supplierDto);
        void Update(int id, SupplierRequestDTO supplierDto);
    }
}
