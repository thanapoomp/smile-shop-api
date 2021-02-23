using System.Collections.Generic;
using System.Threading.Tasks;
using smileshop_api.DTOs.EmployeeDTO;
using smileshop_api.DTOs.ProductDTO;
using SmileShopAPI.Models;

namespace smileshop_api.Services
{
    public interface IEmployeeService
    {
          Task<ServiceResponse<EmployeeDTO_ToReturn>> AddEmployee(EmployeeDTO_ToAdd input);
    }
}