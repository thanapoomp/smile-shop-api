using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace smileshop_api.Models
{
    [Table("StockEditLog")]
    public class StockEditLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int AmountBefore { get; set; }
        [Required]
        public int AmountNumber { get; set; }
        [Required]
        public int AmountAfter { get; set; }
        [StringLength(255)]
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Product Product { get; set; }
    }
}