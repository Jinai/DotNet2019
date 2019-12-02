using SMS.Shared.TransferObjects;
using System.Collections.Generic;

namespace SMS.Shared.Interfaces
{
    public interface ISandwichRepository : IRepository<SandwichTO, int>
    {
        List<SandwichTO> GetSandwichesBySupplier(SupplierTO supplier);
        List<SandwichTO> GetSandwichesByIngredient(List<IngredientTO> ingredients);
        List<SandwichTO> GetSandwichesWithoutIngredient(List<IngredientTO> ingredients);
    }
}