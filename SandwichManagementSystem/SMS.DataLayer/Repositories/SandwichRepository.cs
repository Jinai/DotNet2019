using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.DataLayer.Repositories
{
    public class SandwichRepository : ISandwichRepository
    {
        private readonly SMSContext Context;

        public SandwichRepository(SMSContext context)
        {
            Context = context;
        }

        public List<SandwichTO> GetSandwichesBySupplier(SupplierTO supplier)
        {
            throw new NotImplementedException();
        }

        public List<SandwichTO> GetSandwichesByIngredient(List<IngredientTO> ingredients)
        {
            throw new NotImplementedException();
        }

        public List<SandwichTO> GetSandwichesWithoutIngredient(List<IngredientTO> ingredients)
        {
            throw new NotImplementedException();
        }

        #region CRUD
        public SandwichTO GetById(int id)
        {
            return Context.Sandwiches.AsNoTracking().Include(x => x.SandwichIngredients).ThenInclude(x => x.Ingredient).FirstOrDefault(x => x.Id == id).ToTO();
        }

        public IEnumerable<SandwichTO> GetAll()
        {
            return Context.Sandwiches.AsNoTracking().Include(x => x.SandwichIngredients).ThenInclude(x => x.Ingredient).Select(x => x.ToTO());
        }

        public void Insert(SandwichTO entity)
        {
            Update(entity);
        }

        public void Update(SandwichTO entityToUpdate)
        {
            Context.Sandwiches.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(SandwichTO entityToDelete)
        {
            Context.Sandwiches.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
