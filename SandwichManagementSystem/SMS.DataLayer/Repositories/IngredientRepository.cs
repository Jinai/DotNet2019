using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace SMS.DataLayer.Repositories
{
    public class IngredientRepository : IRepository<IngredientTO, int>
    {
        private readonly SMSContext Context;

        public IngredientRepository(SMSContext context)
        {
            Context = context;
        }

        #region CRUD
        public IngredientTO GetById(int id)
        {
            return Context.Ingredients.AsNoTracking().Include(x => x.SandwichIngredients).FirstOrDefault(x => x.Id == id).ToTO();
        }

        public IEnumerable<IngredientTO> GetAll()
        {
            return Context.Ingredients.AsNoTracking().Include(x => x.SandwichIngredients).Select(x => x.ToTO());
        }

        public void Insert(IngredientTO entity)
        {
            Update(entity);
        }

        public void Update(IngredientTO entityToUpdate)
        {
            Context.Ingredients.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(IngredientTO entityToDelete)
        {
            Context.Ingredients.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
