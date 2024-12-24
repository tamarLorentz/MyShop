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
    public class ProductsController : ControllerBase
    {
        IProductServices productServices;
        IMapper mapper;
        public ProductsController(IProductServices _productrServices, IMapper mapper)
        {
            this.productServices = _productrServices;
            this.mapper = mapper;
        }

        // GET: api/<Product>
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Product>>> Get()
        {
            IEnumerable<Product> products = await productServices.Get();
            IEnumerable<ProductDTO> productsDTO = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            if (productsDTO != null)
            {
                return Ok(productsDTO);
            }
            else
                return NotFound();

        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product =  await productServices.Get(id);
           ProductDTO productsDTO = mapper.Map<Product, ProductDTO>(product);

            if (productsDTO != null)
            {
                return Ok(productsDTO);
            }
            else
                return NotFound();
        }

        
    }
}
