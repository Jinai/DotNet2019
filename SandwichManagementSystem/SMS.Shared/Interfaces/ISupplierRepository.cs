using SMS.Shared.DTO;

namespace SMS.Shared.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierDTO, int>
    {
        SupplierDTO GetCurrentSupplier();
        void SetCurrentSupplier(SupplierDTO supplier);
    }
}
