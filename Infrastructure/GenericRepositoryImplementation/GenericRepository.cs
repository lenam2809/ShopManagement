using Domain.GenericRepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.GenericRepositoryImplementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Add(T entity) => appDbContext.Set<T>().Add(entity);

        public void Delete(T entity) => appDbContext.Set<T>().Remove(entity);

        public async Task<List<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate) => await appDbContext.Set<T>().Where(predicate).ToListAsync();

        public async Task<List<T>> GetAll() => await appDbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(int id) => await appDbContext.Set<T>().FindAsync(id);

        public void Update(T entity) => appDbContext.Update(entity);
    }
}
