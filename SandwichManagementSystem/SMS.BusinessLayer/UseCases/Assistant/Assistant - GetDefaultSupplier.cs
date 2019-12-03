using SMS.Shared.TransferObjects;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant
    {
        public SupplierTO GetDefaultSupplier()
        {
            //if (GetSuppliers().Count(x => x.IsDefault == true) != 1)
            //{
            //    throw new Exception($"GetDefaultSupplier(). Default Supplier not well configured in DB");
            //}

            return UnitOfWork.SupplierRepository.GetDefaultSupplier();
        }
    }
}
