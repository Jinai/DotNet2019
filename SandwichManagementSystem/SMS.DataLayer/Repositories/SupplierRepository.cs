using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace SMS.DataLayer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SMSContext Context;

        public SupplierRepository(SMSContext context)
        {
            Context = context;
        }

        public SupplierTO GetDefaultSupplier()
        {
            throw new System.NotImplementedException();
        }

        public void SetDefaultSupplier(SupplierTO supplier)
        {
            throw new System.NotImplementedException();
        }

        #region CRUD
        public SupplierTO GetById(int id)
        {
            return Context.Suppliers.AsNoTracking().FirstOrDefault(x => x.Id == id).ToTO();
        }

        public IEnumerable<SupplierTO> GetAll()
        {
            return Context.Suppliers.AsNoTracking().Select(x => x.ToTO());
        }

        public void Insert(SupplierTO entity)
        {
            Update(entity);
        }

        public void Update(SupplierTO entityToUpdate)
        {
            Context.Suppliers.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(SupplierTO entityToDelete)
        {
            Context.Suppliers.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
