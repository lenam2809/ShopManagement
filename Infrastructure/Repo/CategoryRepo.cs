using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.GenericRepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class CategoryRepo : GenericRepository<ProductCategory>, ICategory
    {
        public CategoryRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
