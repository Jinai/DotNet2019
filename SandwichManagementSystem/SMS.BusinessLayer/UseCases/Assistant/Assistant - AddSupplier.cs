using SMS.BusinessLayer.Extensions;
using SMS.Shared.Exceptions;
using SMS.Shared.TransferObjects;
using System;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant
    {

        public bool AddSupplier(SupplierTO supplier)
        {
            if (supplier is null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            if (supplier.Id != 0)
            {
                throw new InvalidSupplierException();
            }

            try
            {
                UnitOfWork.SupplierRepository.Insert(supplier.ToDomain().ToTO());
                if (supplier.IsDefault)
                {
                    UnitOfWork.SupplierRepository.SetDefaultSupplier(supplier.ToDomain().ToTO());
                }
                return true;
            }
            catch (InvalidSupplierException ex)
            {
                // Probably need better exception handling
                throw ex;
            }
        }
    }
}
