using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smileshop_api.DTOs.ProductDTO;
using smileshop_api.Services;

namespace smileshop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO_ToAdd input)
        {
            return Ok(await _service.AddProduct(input));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(ProductDTO_ToAdd input, int id)
        {
            return Ok(await _service.EditProduct(input,id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _service.DeleteProduct(id));
        }

        [HttpGet("Active")]
        public async Task<IActionResult> GetActiveProducts()
        {
            return Ok(await _service.GetActiveProducts());
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetProductById(id));
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetFilter([FromQuery]ProductDTO_Filter input)
        {
            return Ok(await _service.GetProductFilter(input));
        }
    }
}