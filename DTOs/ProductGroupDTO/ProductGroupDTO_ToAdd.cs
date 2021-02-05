using System.ComponentModel.DataAnnotations;

namespace smileshop_api.DTOs.ProductGroupDTO
{
    public class ProductGroupDTO_ToAdd
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string IconName { get; set; }
    }
}