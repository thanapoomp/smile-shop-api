using System;
using smileshop_api.DTOs.ProductGroupDTO;

namespace smileshop_api.DTOs.ProductDTO
{
    public class ProductDTO_ToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public ProductGroupDTO_ToReturn ProductGroup { get; set; }
        public bool IsActive { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}