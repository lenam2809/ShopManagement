using Domain.Entities;
using Domain.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IProduct : IGenericRepository<Product>
    {
        Task<List<Product>> GetItemsByCategory(int categoryId);
        Task<Product> GetItem(int id);
        Task<IEnumerable<Product>> GetItems();
        
    }
}
