using SMS.BusinessLayer.Domain;
using SMS.Shared.BTO;
using SMS.Shared.DTO;
using System;

namespace SMS.BusinessLayer.Extensions
{
    public static class SupplierExtensions
    {
        public static SupplierBTO ToBTO(this Supplier supplier)
        {
            if (supplier is null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }

            return new SupplierBTO
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                Email = supplier.Email,
                LanguageChoice = supplier.LanguageChoice,
                IsCurrentSupplier = supplier.IsCurrentSupplier
            };
        }

        public static Supplier ToDomain(this SupplierBTO supplierBTO)
        {
            if (supplierBTO is null)
            {
                throw new ArgumentNullException(nameof(supplierBTO));
            }

            return new Supplier
            {
                Id = supplierBTO.Id,
                Name = supplierBTO.Name,
                ContactName = supplierBTO.ContactName,
                Email = supplierBTO.Email,
                LanguageChoice = supplierBTO.LanguageChoice,
                IsCurrentSupplier = supplierBTO.IsCurrentSupplier
            };
        }

        public static SupplierDTO ToDTO(this Supplier supplier)
        {
            if (supplier is null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }

            return new SupplierDTO
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                Email = supplier.Email,
                LanguageChoice = supplier.LanguageChoice,
                IsCurrentSupplier = supplier.IsCurrentSupplier
            };
        }

        public static Supplier ToDomain(this SupplierDTO supplierDTO)
        {
            return new Supplier
            {
                Id = supplierDTO.Id,
                Name = supplierDTO.Name,
                ContactName = supplierDTO.ContactName,
                Email = supplierDTO.Email,
                LanguageChoice = supplierDTO.LanguageChoice,
                IsCurrentSupplier = supplierDTO.IsCurrentSupplier
            };
        }
    }
}
