using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;
using WebAPI.Models;
using WebAPI.Resources;
using WebAPI.Services.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category != null)
            {
                return Ok(_mapper.Map<Category, CategoryResource>(category));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<CategoryResource, Category>(resource);
            await _categoryService.AddAsync(category);

            var categoryResource = _mapper.Map<Category, CategoryResource>(category);
            return Ok(categoryResource);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> PutAsync(long id, [FromBody] CategoryResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Category? category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            var categoryUpdate = _mapper.Map<CategoryResource, Category>(resource);

            await _categoryService.Update(id, categoryUpdate);

            var categoryResource = _mapper.Map<Category, CategoryResource>(categoryUpdate);

            return Ok(categoryResource);
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindByParams([FromQuery] string? name, [FromQuery] bool status)
        {
            var categories = await _categoryService.FindCategoriesByParamsAsync(name, status);
            return Ok(categories);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Category? category = await _categoryService.GetCategoryByIdAsync(id);

            if (category != null)
            {
                await _categoryService.DeleteCategory(category);
                return Ok();
            }

            return NotFound();
        }
    }
}
