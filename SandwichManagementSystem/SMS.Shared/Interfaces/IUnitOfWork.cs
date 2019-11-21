using SMS.Shared.DTO;
using System;

namespace SMS.Shared.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<IngredientDTO, int> IngredientRepository { get; }
        ISandwichRepository SandwichRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}
