using SMS.DataLayer.Entities;
using SMS.Shared.TransferObjects;
using System;

namespace SMS.DataLayer.Extensions
{
    public static class SupplierExtensions
    {
        public static SupplierTO ToTO(this SupplierEF supplierEF)
        {
            if (supplierEF is null)
            {
                throw new ArgumentNullException(nameof(supplierEF));
            }

            return new SupplierTO
            {
                Id = supplierEF.Id,
                Name = supplierEF.Name,
                ContactName = supplierEF.ContactName,
                Email = supplierEF.Email,
                LanguageChoice = supplierEF.LanguageChoice,
                IsDefault = supplierEF.IsCurrentSupplier
            };
        }

        public static SupplierEF ToEF(this SupplierTO supplierTO)
        {
            if (supplierTO is null)
            {
                throw new ArgumentNullException(nameof(supplierTO));
            }

            return new SupplierEF
            {
                Id = supplierTO.Id,
                Name = supplierTO.Name,
                ContactName = supplierTO.ContactName,
                Email = supplierTO.Email,
                LanguageChoice = supplierTO.LanguageChoice,
                IsCurrentSupplier = supplierTO.IsDefault
            };
        }
    }
}
