using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Extensions;
using SMS.Shared.DTO;
using SMS.Shared.Interfaces;
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

        public SupplierDTO GetCurrentSupplier()
        {
            throw new System.NotImplementedException();
        }

        public void SetCurrentSupplier(SupplierDTO supplier)
        {
            throw new System.NotImplementedException();
        }

        #region CRUD
        public SupplierDTO GetById(int id)
        {
            return Context.Suppliers.AsNoTracking().FirstOrDefault(x => x.Id == id).ToDTO();
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            return Context.Suppliers.AsNoTracking().Select(x => x.ToDTO());
        }

        public void Insert(SupplierDTO entity)
        {
            Update(entity);
        }

        public void Update(SupplierDTO entityToUpdate)
        {
            Context.Suppliers.Update(entityToUpdate.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(SupplierDTO entityToDelete)
        {
            Context.Suppliers.Remove(entityToDelete.ToEF());
        }
        #endregion
    }
}
