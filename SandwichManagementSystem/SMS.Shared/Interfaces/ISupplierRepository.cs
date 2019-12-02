using SMS.Shared.TransferObjects;

namespace SMS.Shared.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierTO, int>
    {
        SupplierTO GetCurrentSupplier();
        void SetCurrentSupplier(SupplierTO supplier);
    }
}
