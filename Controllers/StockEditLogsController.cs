using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smileshop_api.DTOs.ProductDTO;
using smileshop_api.DTOs.StockEditLogDTO;
using smileshop_api.Services;

namespace smileshop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockEditLogsController: ControllerBase
    {
        private readonly IStockEditLogService service;

        public StockEditLogsController(IStockEditLogService service)
        {
            this.service = service;
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter ([FromQuery]StockEditLogDTO_Filter input)
        {
            return Ok(await service.GetStockEditFilter(input));
        }

        [HttpPost]
        public async Task<IActionResult> Post (StockEditLogDTO_ToAdd input)
        {
            return Ok(await service.AddStockEditLog(input));
        }
    }
}