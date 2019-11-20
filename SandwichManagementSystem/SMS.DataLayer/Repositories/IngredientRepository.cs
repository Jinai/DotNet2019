using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.DTO;
using SMS.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SMS.DataLayer.Repositories
{
    public class IngredientRepository : IRepository<IngredientDTO, int>
    {
        private readonly SMSContext Context;

        public IngredientRepository(SMSContext context)
        {
            Context = context;
        }

        #region CRUD
        public IngredientDTO GetById(int id)
        {
            return Context.Ingredients.AsNoTracking().Include(x => x.SandwichIngredients).FirstOrDefault(x => x.Id == id).ToDTO();
        }

        public IEnumerable<IngredientDTO> GetAll()
        {
            return Context.Ingredients.AsNoTracking().Include(x => x.SandwichIngredients).Select(x => x.ToDTO());
        }

        public void Insert(IngredientDTO entity)
        {
            Update(entity);
        }

        public void Update(IngredientDTO entityToUpdate)
        {
            Context.Ingredients.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(IngredientDTO entityToDelete)
        {
            Context.Ingredients.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
