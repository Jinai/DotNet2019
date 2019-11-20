using System.Collections.Generic;

namespace SMS.DataLayer
{
    public interface IRepository<T, U>
    {
        T GetById(U id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entityToUpdate);
        void Delete(U id);
        void Delete(T entityToDelete);
    }
}
