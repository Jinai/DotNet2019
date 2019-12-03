using SMS.Shared.TransferObjects;
using System;

namespace SMS.Shared.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<IngredientTO, int> IngredientRepository { get; }
        IMealRepository MealRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Save();
    }
}
