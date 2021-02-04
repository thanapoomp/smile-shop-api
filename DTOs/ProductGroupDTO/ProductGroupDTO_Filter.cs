using SmileShopAPI.DTOs;

namespace smileshop_api.DTOs.ProductGroupDTO
{
    public class ProductGroupDTO_Filter : PaginationDto
    {
        public string Name { get; set; }
        
    }
}