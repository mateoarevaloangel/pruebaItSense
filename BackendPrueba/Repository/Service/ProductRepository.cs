using BackendPrueba.Data;
using BackendPrueba.Models;
using BackendPrueba.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackendPrueba.Repository.Service
{
    public class ProductRepository : IProductRepository
    {
        //constructor del repositorio
        public ProductRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }private readonly AppDbContext appDbContext;
        
        public async Task<Product> AddProduct(Product product)
        {
            var result = await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteProduct(int productId)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == productId);
            if (result != null)
            {
                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products.ToListAsync();
            
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await appDbContext.Products.FirstOrDefaultAsync(e => e.ProductId == productId);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == product.ProductId);

            if (result != null)
            {
                result.Name = product.Name;
                result.Status = product.Status;
                result.Stock = product.Stock;
                result.TypeManofacture = product.TypeManofacture;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
