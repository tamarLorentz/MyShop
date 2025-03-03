using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiManagerContext context;
        public CategoryRepository(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await context.Categories.ToListAsync();
        }
    }
}


