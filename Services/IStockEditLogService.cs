using System.Collections.Generic;
using System.Threading.Tasks;
using smileshop_api.DTOs.StockEditLogDTO;
using SmileShopAPI.Models;

namespace smileshop_api.Services
{
    public interface IStockEditLogService
    {
        Task<ServiceResponse<StockEditLogDTO_ToReturn>> AddStockEditLog(StockEditLogDTO_ToAdd input);
        Task<ServiceResponseWithPagination<List<StockEditLogDTO_ToReturn>>> GetStockEditFilter(StockEditLogDTO_Filter input);
    }
}