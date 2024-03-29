using System;
using ManagementSystem.Data;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Services
{
    public interface ISupplierService
    {
        Task<int> CreateSupplierAsync(Supplier supplier);
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task UpdateSupplierAsync(int id, Supplier updatedSupplier);
        Task DeleteSupplierAsync(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        private readonly IViaCEPService _viaCEPService;


        public SupplierService(ApplicationDbContext context, IViaCEPService viaCEPService)
        {
            _context = context;
            _viaCEPService = viaCEPService;
        }


        public async Task<int> CreateSupplierAsync(Supplier supplier)
        {
            try
            {
                string address = await _viaCEPService.GetAddressAsync(supplier.CEP);
                supplier.Address = address;
                _context.Suppliers.Add(supplier);
                await _context.SaveChangesAsync();
                return supplier.Id;
            }
            catch (DbUpdateException ex)
            {
                throw; 
            }
        }


        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task UpdateSupplierAsync(int id, Supplier updatedSupplier)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(id);
            if (existingSupplier == null)
            {
                throw new ArgumentException("Supplier not found.");
            }

            existingSupplier.Name = updatedSupplier.Name;
            existingSupplier.CNPJ = updatedSupplier.CNPJ;
            existingSupplier.Address = updatedSupplier.Address;
            existingSupplier.Phone = updatedSupplier.Phone;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }

}

