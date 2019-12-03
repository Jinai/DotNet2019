using SMS.Shared.TransferObjects;
using System.Collections.Generic;

namespace SMS.Shared.Interfaces
{
    public interface IMealRepository : IRepository<MealTO, int>
    {
        List<MealTO> GetMealsBySupplier(SupplierTO supplier);
        List<MealTO> GetMealsByIngredient(List<IngredientTO> ingredients);
        List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> ingredients);
    }
}