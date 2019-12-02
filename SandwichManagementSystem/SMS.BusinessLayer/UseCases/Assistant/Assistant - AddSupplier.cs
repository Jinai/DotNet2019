using SMS.BusinessLayer.Extensions;
using SMS.Shared.TransferObjects;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant
    {

        public bool AddSupplier(SupplierTO supplier)
        {
            // TODO: Exception handling
            UnitOfWork.SupplierRepository.Insert(supplier.ToDomain().ToTO());
            return true;
        }
    }
}
