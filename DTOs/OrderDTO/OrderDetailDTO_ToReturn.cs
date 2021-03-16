namespace smileshop_api.DTOs.OrderDTO
{
    public class OrderDetailDTO_ToReturn
    {
                public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }
    }
}