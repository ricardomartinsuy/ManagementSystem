using System;
using ManagementSystem.Models;
using ManagementSystem.Data;

namespace ManagementSystem.Services
{
	public class ProductService
	{
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }


        public async Task<Product> UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found");
            }

            existingProduct.Description = product.Description;
            existingProduct.Brand = product.Brand;
            existingProduct.UnitOfMeasure = product.UnitOfMeasure;

            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.ListProducts();
        }
    }
}

