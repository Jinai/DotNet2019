using SMS.Shared.DTO;
using System.Collections.Generic;

namespace SMS.Shared.Interfaces
{
    public interface ISandwichRepository : IRepository<SandwichDTO, int>
    {
        List<SandwichDTO> GetSandwichesBySupplier(SupplierDTO supplier);
        List<SandwichDTO> GetSandwichesByIngredient(List<IngredientDTO> ingredients);
        List<SandwichDTO> GetSandwichesWithoutIngredient(List<IngredientDTO> ingredients);
    }
}