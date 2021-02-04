using SmileShopAPI.Validations;

namespace SmileShopAPI.DTOs
{
    public class RoleDtoAdd
    {
        [FirstLetterUpperCase]
        public string RoleName { get; set; }
    }
}