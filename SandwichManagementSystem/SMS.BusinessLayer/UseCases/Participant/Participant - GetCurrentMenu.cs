using SMS.BusinessLayer.Extensions;
using SMS.Shared.BTO;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<SandwichBTO> GetCurrentMenu()
        {
            var Supplier = UnitOfWork.SupplierRepository.GetCurrentSupplier();

            return UnitOfWork.SandwichRepository
                    .GetSandwichesBySupplier(Supplier)
                    .Select(x => x.ToDomain().ToBTO())
                     .ToList();
        }
    }
}
