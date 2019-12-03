using SMS.Shared.TransferObjects;
using System.Collections.Generic;

namespace SMS.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<SandwichTO> GetCurrentMenu()
        {
            var Supplier = UnitOfWork.SupplierRepository.GetCurrentSupplier();

            return UnitOfWork.SandwichRepository.GetSandwichesBySupplier(Supplier);

            //return UnitOfWork.SandwichRepository
            //        .GetSandwichesBySupplier(Supplier)
            //        .Select(x => x.ToDomain().ToBTO())
            //        .ToList();
        }
    }
}
