using System;
using System.ComponentModel.DataAnnotations;
using smileshop_api.DTOs.ProductDTO;

namespace smileshop_api.DTOs.StockEditLogDTO
{
    public class StockEditLogDTO_ToReturn
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AmountBefore { get; set; }
        public int AmountNumber { get; set; }
        public int AmountAfter { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductDTO_ToReturn Product { get; set; }
    }
}