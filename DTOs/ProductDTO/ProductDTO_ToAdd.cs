using System.ComponentModel.DataAnnotations;

namespace smileshop_api.DTOs.ProductDTO
{
    public class ProductDTO_ToAdd
    {
         [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int ProductGroupId { get; set; }
    }
}