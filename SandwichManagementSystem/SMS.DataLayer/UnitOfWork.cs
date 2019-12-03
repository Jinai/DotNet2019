using SMS.DataLayer.Repositories;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;

namespace SMS.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private SMSContext Context;
        private IRepository<IngredientTO, int> ingredientRepository;
        private IMealRepository mealRepository;
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

        public IMealRepository MealRepository
        {
            get
            {
                if (mealRepository == null)
                    mealRepository = new MealRepository(Context);
                return mealRepository;
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

            mealRepository = null;
        }
    }
}
