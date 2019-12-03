using SMS.BusinessLayer.Extensions;
using SMS.Shared.TransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<MealTO> GetCurrentMenu()
        {
            var Supplier = UnitOfWork.SupplierRepository.GetDefaultSupplier();

            return UnitOfWork.MealRepository.GetMealsBySupplier(Supplier);

            //return UnitOfWork.MealRepository
            //       .GetMealsBySupplier(Supplier)
            //       .Select(x => x.ToDomain().ToTO())
            //       .ToList();
        }
    }
}
