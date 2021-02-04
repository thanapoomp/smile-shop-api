using System.Collections.Generic;
using System.Threading.Tasks;
using smileshop_api.DTOs.ProductGroupDTO;
using SmileShopAPI.Models;

namespace smileshop_api.Services
{
    public interface IProductGroupService
    {
        Task<ServiceResponse<List<ProductGroupDTO_ToReturn>>> GetAllProductGroups();
        Task<ServiceResponse<List<ProductGroupDTO_ToReturn>>> GetActiveProductGroups();
        Task<ServiceResponse<ProductGroupDTO_ToReturn>> AddProductGroup(ProductGroupDTO_ToAdd input);
        Task<ServiceResponse<ProductGroupDTO_ToReturn>> EditProductGroup(ProductGroupDTO_ToAdd input, int id);
        Task<ServiceResponse<ProductGroupDTO_ToReturn>> DeleteProductGroup(int id);
        Task<ServiceResponse<ProductGroupDTO_ToReturn>> GetProductGroupById(int id);
        Task<ServiceResponseWithPagination<List<ProductGroupDTO_ToReturn>>> GetProductGroupFilter(ProductGroupDTO_Filter input);
    }
}