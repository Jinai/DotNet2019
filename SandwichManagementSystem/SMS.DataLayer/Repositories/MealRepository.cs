using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.DataLayer.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly SMSContext Context;

        public MealRepository(SMSContext context)
        {
            Context = context;
        }

        public List<MealTO> GetMealsBySupplier(SupplierTO supplier)
        {
            throw new NotImplementedException();
        }

        public List<MealTO> GetMealsByIngredient(List<IngredientTO> ingredients)
        {
            throw new NotImplementedException();
        }

        public List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> ingredients)
        {
            throw new NotImplementedException();
        }

        #region CRUD
        public MealTO GetById(int id)
        {
            return Context.Meals.AsNoTracking().Include(x => x.MealCompositions).ThenInclude(x => x.Ingredient).FirstOrDefault(x => x.Id == id).ToTO();
        }

        public IEnumerable<MealTO> GetAll()
        {
            return Context.Meals.AsNoTracking().Include(x => x.MealCompositions).ThenInclude(x => x.Ingredient).Select(x => x.ToTO());
        }

        public void Insert(MealTO entity)
        {
            Update(entity);
        }

        public void Update(MealTO entityToUpdate)
        {
            Context.Meals.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(MealTO entityToDelete)
        {
            Context.Meals.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
