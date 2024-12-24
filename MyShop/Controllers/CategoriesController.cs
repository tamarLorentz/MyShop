using Entites;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;
using DTO;
using System.Collections.Generic;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IMapper mapper;
        ICategoryServices categoryServices;

        public CategoriesController(ICategoryServices categoryServices, IMapper mapper)
        {
            this.categoryServices = categoryServices;
            this.mapper = mapper;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            IEnumerable <Category> Categoryies = await categoryServices.Get();
            IEnumerable<GetCategoryDTO> CategoryiesDTO = mapper.Map<IEnumerable<Category>, IEnumerable<GetCategoryDTO>>(Categoryies);

            if (CategoryiesDTO != null)
            {
                return Ok(CategoryiesDTO);
            }
            else
                return NoContent();
        }

       
    }
}
