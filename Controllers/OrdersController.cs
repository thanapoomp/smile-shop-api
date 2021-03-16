using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smileshop_api.DTOs.OrderDTO;
using smileshop_api.DTOs.ProductGroupDTO;
using smileshop_api.Services;

namespace smileshop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDTO_ToAdd input)
        {
            return Ok(await service.AddOrder(input));
        }



    }
}