using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Microsoft.EntityFrameworkCore;

namespace Resources
{
    public class OrderRepository : IOrderRepository
    {
        ApiManagerContext context;
        public OrderRepository(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }

        public async Task<Order> Get(int id)
        {
            //var order =  await context.Orders.FindAsync(id);
            var order = await context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);  
            return order;
        }


        public async Task<Order> Post(Order order)

        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
