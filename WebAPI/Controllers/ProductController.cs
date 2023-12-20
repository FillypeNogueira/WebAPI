using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;
using WebAPI.Models;
using WebAPI.Resources;
using WebAPI.Services.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            var response = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
                return Ok(_mapper.Map<Product, ProductResource>(product));

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<ProductResource, Product>(resource);

            await _productService.AddAsync(product);

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] ProductResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<ProductResource, Product>(resource);

            await _productService.Update(id, product);

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindByParams([FromQuery] string? description, [FromQuery] long? categoryId, [FromQuery] bool status)
        {
            var products = await _productService.FindProductsByParamsAsync(description, categoryId, status);
            return Ok(products);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            Product? product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                await _productService.DeleteProduct(product);
                return Ok();
            }
            return NotFound();
        }
    }
}
