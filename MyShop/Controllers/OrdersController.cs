using AutoMapper;
using DTO;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Resources;
using Services;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderServices  orderServices;
        IMapper  mapper;

        public OrdersController(IOrderServices orderServices, IMapper mapper)
        {
            this.orderServices = orderServices;
            this.mapper = mapper;
        }

      

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderDTO>> Get(int id)
        {
            Order order =  await orderServices.Get(id);
          // IEnumerable< int> arr =  order.OrderItems.Select(p => p.ProuductId);
            GetOrderDTO orderDTO = mapper.Map<Order, GetOrderDTO>(order);
            if (orderDTO != null)
            {
                return Ok(orderDTO);
            }
            else return NoContent();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<PostOrderDTO>> Post([FromBody] Order order)
        {
            Order neworder =  await orderServices.Post(order);
            PostOrderDTO orderDTO = mapper.Map<Order, PostOrderDTO>(neworder);
            return CreatedAtAction(nameof(Get), new { id = orderDTO.Id }, orderDTO);
        }

    }
}
