using SMS.DataLayer.Repositories;
using SMS.Shared.DTO;
using SMS.Shared.Interfaces;
using System;

namespace SMS.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private SMSContext Context;
        private IRepository<IngredientDTO, int> ingredientRepository;
        private ISandwichRepository sandwichRepository;
        private ISupplierRepository supplierRepository;

        #region Properties
        public IRepository<IngredientDTO, int> IngredientRepository
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(Context);
                return ingredientRepository;
            }
        }
        
        public ISandwichRepository SandwichRepository
        {
            get
            {
                if (sandwichRepository == null)
                    sandwichRepository = new SandwichRepository(Context);
                return sandwichRepository;
            }
        }
        
        public ISupplierRepository SupplierRepository
        {
            get
            {
                if (supplierRepository == null)
                    supplierRepository = new SupplierRepository(Context);
                return supplierRepository;
            }
        }
        #endregion

        public UnitOfWork(SMSContext context)
        {
            Context = context ?? new SMSContext();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            Context = null;

            sandwichRepository = null;
        }
    }
}
