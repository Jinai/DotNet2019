using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.DTO;
using SMS.Shared.Interfaces;
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

        public List<SandwichDTO> GetSandwichesBySupplier(SupplierDTO supplier)
        {
            throw new NotImplementedException();
        }

        public List<SandwichDTO> GetSandwichesByIngredient(List<IngredientDTO> ingredients)
        {
            throw new NotImplementedException();
        }

        public List<SandwichDTO> GetSandwichesWithoutIngredient(List<IngredientDTO> ingredients)
        {
            throw new NotImplementedException();
        }

        #region CRUD
        public SandwichDTO GetById(int id)
        {
            return Context.Sandwiches.AsNoTracking().Include(x => x.SandwichIngredients).ThenInclude(x => x.Ingredient).FirstOrDefault(x => x.Id == id).ToDTO();
        }

        public IEnumerable<SandwichDTO> GetAll()
        {
            return Context.Sandwiches.AsNoTracking().Include(x => x.SandwichIngredients).ThenInclude(x => x.Ingredient).Select(x => x.ToDTO());
        }

        public void Insert(SandwichDTO entity)
        {
            Update(entity);
        }

        public void Update(SandwichDTO entityToUpdate)
        {
            Context.Sandwiches.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(SandwichDTO entityToDelete)
        {
            Context.Sandwiches.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
