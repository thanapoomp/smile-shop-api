using System;
using System.Collections.Generic;
using smileshop_api.Models;

namespace smileshop_api.DTOs.OrderDTO
{
    public class OrderDetailDTO_ToAdd
    {        
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }
    }
}