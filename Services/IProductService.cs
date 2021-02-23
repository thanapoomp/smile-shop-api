using System.Collections.Generic;
using System.Threading.Tasks;
using smileshop_api.DTOs.ProductDTO;
using SmileShopAPI.Models;

namespace smileshop_api.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductDTO_ToReturn>>> GetAllProducts();
        Task<ServiceResponse<List<ProductDTO_ToReturn>>> GetActiveProducts();
        Task<ServiceResponse<List<ProductDTO_ToReturn>>> GetByProductGroupId(int productGroupId);
        Task<ServiceResponse<ProductDTO_ToReturn>> AddProduct(ProductDTO_ToAdd input);
        Task<ServiceResponse<ProductDTO_ToReturn>> EditProduct(ProductDTO_ToAdd input, int id);
        Task<ServiceResponse<ProductDTO_ToReturn>> DeleteProduct(int id);
        Task<ServiceResponse<ProductDTO_ToReturn>> GetProductById(int id);
        Task<ServiceResponseWithPagination<List<ProductDTO_ToReturn>>> GetProductFilter(ProductDTO_Filter input);
    }
}