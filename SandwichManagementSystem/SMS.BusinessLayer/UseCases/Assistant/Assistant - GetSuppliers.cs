using SMS.Shared.TransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant
    {
        public List<SupplierTO> GetSuppliers()
        {
            return UnitOfWork.SupplierRepository.GetAll().ToList();
        }
    }
}
