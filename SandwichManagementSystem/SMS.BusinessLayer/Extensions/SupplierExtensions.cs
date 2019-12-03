using SMS.BusinessLayer.Domain;
using SMS.Shared.TransferObjects;
using System;

namespace SMS.BusinessLayer.Extensions
{
    public static class SupplierExtensions
    {
        public static Supplier ToDomain(this SupplierTO supplierTO)
        {
            var supplier = new Supplier
            {
                Id = supplierTO.Id,
                Name = supplierTO.Name,
                ContactName = supplierTO.ContactName,
                Email = supplierTO.Email,
                LanguageChoice = supplierTO.LanguageChoice,
                IsDefault = supplierTO.IsDefault
            };

            supplier.CheckValidity();

            return supplier;
        }

        public static SupplierTO ToTO(this Supplier supplier)
        {
            if (supplier is null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }

            return new SupplierTO
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                Email = supplier.Email,
                LanguageChoice = supplier.LanguageChoice,
                IsDefault = supplier.IsDefault
            };
        }
    }
}
