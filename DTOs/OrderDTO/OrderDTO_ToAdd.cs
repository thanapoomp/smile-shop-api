using System;
using System.Collections.Generic;
using smileshop_api.Models;

namespace smileshop_api.DTOs.OrderDTO
{
    public class OrderDTO_ToAdd
    {
        public List<OrderDetailDTO_ToAdd> OrderDetails { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double NetTotal { get; set; }
    }
}