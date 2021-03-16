using AutoMapper;
using smileshop_api.DTOs.EmployeeDTO;
using smileshop_api.DTOs.OrderDTO;
using smileshop_api.DTOs.ProductDTO;
using smileshop_api.DTOs.ProductGroupDTO;
using smileshop_api.DTOs.StockEditLogDTO;
using smileshop_api.Models;
using SmileShopAPI.DTOs;
using SmileShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileShopAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>()
                .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Name));
            CreateMap<RoleDtoAdd, Role>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.RoleName)); ;
            CreateMap<UserRole, UserRoleDto>();

            CreateMap<ProductGroup,ProductGroupDTO_ToReturn>().ReverseMap();

            CreateMap<Product,ProductDTO_ToReturn>().ReverseMap();

            CreateMap<StockEditLog,StockEditLogDTO_ToReturn>().ReverseMap();

            CreateMap<Employee,EmployeeDTO_ToReturn>().ReverseMap();

            CreateMap<Order,OrderDTO_ToReturn>().ReverseMap();

            CreateMap<OrderDetail,OrderDetailDTO_ToReturn>().ReverseMap();
        }
    }
}