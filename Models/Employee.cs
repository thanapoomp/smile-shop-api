using System.ComponentModel.DataAnnotations;

namespace smileshop_api.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string ImageName { get; set; }
    }
}