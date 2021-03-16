using System.Collections.Generic;
using System.Threading.Tasks;
using smileshop_api.DTOs.OrderDTO;
using SmileShopAPI.Models;

namespace smileshop_api.Services
{
    public interface IOrderService
    {
        Task<ServiceResponse<OrderDTO_ToReturn>> AddOrder(OrderDTO_ToAdd input);
        
    }
}