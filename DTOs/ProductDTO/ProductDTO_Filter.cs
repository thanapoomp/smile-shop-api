using SmileShopAPI.DTOs;

namespace smileshop_api.DTOs.ProductDTO
{
    public class ProductDTO_Filter : PaginationDto
    {
        public string Name { get; set; }
        public bool? IsShowInActive { get; set; }
        public int? ProductGroupId { get; set; }
    }
}