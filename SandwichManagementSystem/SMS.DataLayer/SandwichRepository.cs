using SMS.DataLayer.Extensions;
using SMS.Shared.DTO;
using System;
using System.Collections.Generic;

namespace SMS.DataLayer
{
    public class SandwichRepository : IRepository<SandwichDTO, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(SandwichDTO entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SandwichDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public SandwichDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SandwichDTO entity)
        {
            using (var ctx = new SandwichContext())
            {
                ctx.Sandwiches.Add(entity.ToEF());
                ctx.SaveChanges();
            }
        }

        public void Update(SandwichDTO entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
