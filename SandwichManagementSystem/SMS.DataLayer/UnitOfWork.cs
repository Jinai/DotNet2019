using SMS.DataLayer.Repositories;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;

namespace SMS.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private SMSContext Context;
        private IRepository<IngredientTO, int> ingredientRepository;
        private ISandwichRepository sandwichRepository;
        private ISupplierRepository supplierRepository;

        #region Properties
        public IRepository<IngredientTO, int> IngredientRepository
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
