using SMS.BusinessLayer.Extensions;
using SMS.Shared.BTO;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant
    {

        public bool AddSupplier(SupplierBTO supplier)
        {
            // TODO: Exception handling
            UnitOfWork.SupplierRepository.Insert(supplier.ToDomain().ToDTO());
            return true;
        }
    }
}
