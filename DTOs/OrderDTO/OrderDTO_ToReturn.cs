using System;
using System.Collections.Generic;
using smileshop_api.Models;

namespace smileshop_api.DTOs.OrderDTO
{
    public class OrderDTO_ToReturn
    {
         public int Id { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double NetTotal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public List<OrderDetailDTO_ToReturn> OrderDetails { get; set; }
    }
}