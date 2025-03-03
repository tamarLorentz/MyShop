using Entites;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;
using DTO;
using System.Collections.Generic;
using AutoMapper;
using Repository;
using Microsoft.Extensions.Caching.Memory;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryServices _categoryServices;
        private readonly IMemoryCache _memoryCache;

        public CategoriesController(ICategoryServices categoryServices, IMapper mapper, IMemoryCache memoryCache)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDTO>>> Get()
        {
            if (!_memoryCache.TryGetValue("CategoriesCache", out IEnumerable<Category> categories))
            {
                categories = await _categoryServices.Get();

                if (categories == null || !categories.Any())
                {
                    return NotFound();
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                };

                _memoryCache.Set("CategoriesCache", categories, cacheEntryOptions);
            }

            return Ok(_mapper.Map<IEnumerable<Category>, IEnumerable<GetCategoryDTO>>(categories));
        }
    }
}

