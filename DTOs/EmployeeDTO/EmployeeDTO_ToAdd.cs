using Microsoft.AspNetCore.Http;

namespace smileshop_api.DTOs.EmployeeDTO
{
    public class EmployeeDTO_ToAdd
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string ImageName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}