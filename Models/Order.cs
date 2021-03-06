using System;
using System.Collections.Generic;

namespace smileshop_api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double NetTotal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public List<OrderDetail> OrderDetails { get; set; }
    }
}