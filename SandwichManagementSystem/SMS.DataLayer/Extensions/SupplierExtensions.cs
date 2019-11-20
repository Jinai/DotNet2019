using SMS.DataLayer.Entities;
using SMS.Shared.DTO;
using System;

namespace SMS.DataLayer.Extensions
{
    public static class SupplierExtensions
    {
        public static SupplierDTO ToDTO(this SupplierEF supplierEF)
        {
            if (supplierEF is null)
            {
                throw new ArgumentNullException(nameof(supplierEF));
            }

            return new SupplierDTO
            {
                Id = supplierEF.Id,
                Name = supplierEF.Name,
                ContactName = supplierEF.ContactName,
                Email = supplierEF.Email,
                LanguageChoice = supplierEF.LanguageChoice,
                IsCurrentSupplier = supplierEF.IsCurrentSupplier
            };
        }

        public static SupplierEF ToEF(this SupplierDTO supplierDTO)
        {
            if (supplierDTO is null)
            {
                throw new ArgumentNullException(nameof(supplierDTO));
            }

            return new SupplierEF
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
