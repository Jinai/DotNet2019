using System.Collections.Generic;

namespace SMS.Shared.Interfaces
{
    public interface IRepository<T, U>
    {
        T GetById(U id);
        IEnumerable<T> GetAll();
        // TODO: Return inserted entity
        void Insert(T entity);
        // TODO: Return updated entity
        void Update(T entityToUpdate);
        void Delete(U id);
        void Delete(T entityToDelete);
    }
}
