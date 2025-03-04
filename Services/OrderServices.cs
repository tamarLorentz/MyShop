using Entites;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class OrderServices : IOrderServices
{
   IProductRepository productRepository;
   IOrderRepository orderRepository;
    private readonly ILogger<OrderServices> logger;
    public OrderServices(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderServices> logger)
    {
        this.orderRepository = orderRepository;
        this.productRepository = productRepository;
        this.logger = logger;
    }

    public Task<Order> Get(int id)
    {
        return orderRepository.Get(id);
    }
    //date&sum


    public async Task<Order> Post(Order order)
    {
     
        OrderSum(order);

        order.Date = DateOnly.FromDateTime(DateTime.Now);
        return await orderRepository.Post(order);

    }
    private async void OrderSum(Order order)
    {
            double? sum = 0;
            IEnumerable<Product> products1 = await productRepository.Get(null, null, new int?[0], null);
            foreach (OrderItem orderItem in order.OrderItems)
            {

                Product? p = products1.FirstOrDefault(product => product.Id == orderItem.ProuductId);
                sum += p?.Price * orderItem.Quantity;
            };
            if (sum != order.Sum)
            {
                logger.LogCritical("somone try to change the order sum");
                order.Sum = sum;
            }
    }
}


