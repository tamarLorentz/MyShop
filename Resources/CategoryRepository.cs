using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    public class CategoryRepository : ICategoryRepository
    {
        ApiManagerContext context;
        public CategoryRepository(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await context.Categories.ToListAsync<Category>();
        }
    }
}
