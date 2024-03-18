using Application.Contracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            Product = new ProductRepo(appDbContext);
            Category = new CategoryRepo(appDbContext);
        }

        public IProduct Product { get; private set; }

        public ICategory Category { get; private set; }

        public void Dispose()
        {
            appDbContext.Dispose();
        }

        public int SaveChanges()
        {
            return appDbContext.SaveChanges();
        }
    }
}
