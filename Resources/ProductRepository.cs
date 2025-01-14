using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    public class ProductRepository : IProductRepository
    {
        ApiManagerContext context;
        public ProductRepository(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }
        public async Task< IEnumerable<Product>> Get(int ? minPrice, int ? maxPrice, int ?[] categoryIds, string ? desc)
        {
            
            var query = context.Products.Where(Product =>
             (desc == null ? (true) : (Product.Description.Contains(desc)))
             && (minPrice == null ? (true) : (Product.Price >= minPrice))
             && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
             && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))
             .OrderBy(Product => Product.Price).Include(p => p.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;


           // return await context.Products.Include(p=>p.Category).ToListAsync(); 
        }

        public async Task<Product> Get(int id)

        {
            return await context.Products.Include(p => p.Category).FirstOrDefaultAsync(p=>p.Id==id);
        }

    }
}
