using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.GenericRepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class ProductRepo : GenericRepository<Product>, IProduct
    {
        private readonly AppDbContext appDbContext;
        public ProductRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await appDbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await appDbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;

        }

        public async Task<List<Product>> GetItemsByCategory(int categoryId)
        {
            return await appDbContext.Products.Include(p => p.ProductCategory).Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}
