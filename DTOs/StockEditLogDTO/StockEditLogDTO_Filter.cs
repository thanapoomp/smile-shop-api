using SmileShopAPI.DTOs;

namespace smileshop_api.DTOs.StockEditLogDTO
{
    public class StockEditLogDTO_Filter : PaginationDto
    {
        public int? ProductGroupId { get; set; }
        public int? ProductId { get; set; }
    }
}