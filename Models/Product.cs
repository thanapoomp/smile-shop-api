using System;
using System.Collections.Generic;

namespace smileshop_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public List<StockEditLog> StockEditLog { get; set; }
        public bool IsActive { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}