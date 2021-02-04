using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smileshop_api.DTOs.ProductGroupDTO;
using smileshop_api.Services;

namespace smileshop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductGroupsController : ControllerBase
    {
        private readonly IProductGroupService service;

        public ProductGroupsController(IProductGroupService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductGroups()
        {
            return Ok(await service.GetAllProductGroups());
        }

        [HttpGet("Active")]
        public async Task<IActionResult> GetActiveProductGroups()
        {
            return Ok(await service.GetActiveProductGroups());
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetProductGroupfilter([FromQuery] ProductGroupDTO_Filter input)
        {
            return Ok(await service.GetProductGroupFilter(input));
        }

        [HttpPost]
        public async Task<IActionResult> AddProductGroup(ProductGroupDTO_ToAdd input)
        {
            return Ok(await service.AddProductGroup(input));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProductGroup(ProductGroupDTO_ToAdd input,int id)
        {
            return Ok(await service.EditProductGroup(input,id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGroup(int id)
        {
            return Ok(await service.DeleteProductGroup(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductGroupById(int id)
        {
            return Ok(await service.GetProductGroupById(id));
        }


    }
}