using Entites;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        IOrderRepository orderRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<Order> Get(int id)
        {
            return orderRepository.Get(id);
        }

        public Task<Order> Post(Order order)
        {
            return orderRepository.Post(order);

        }
    }
}


