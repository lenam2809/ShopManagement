using Domain.Entities;
using Domain.GenericRepositoryInterface;

namespace Application.Contracts
{
    public interface ICategory : IGenericRepository<ProductCategory>
    {
    }
}
