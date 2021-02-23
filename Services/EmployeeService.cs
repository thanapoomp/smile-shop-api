using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using smileshop_api.DTOs.ProductGroupDTO;
using smileshop_api.Models;
using SmileShopAPI.Data;
using SmileShopAPI.Models;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;
using SmileShopAPI.Helpers;
using SmileShopAPI.Services;
using smileshop_api.DTOs.EmployeeDTO;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace smileshop_api.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        private readonly ILogger<ProductGroupService> logger;
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment environment;

        public EmployeeService(AppDBContext context, IMapper mapper, ILogger<ProductGroupService> logger, IHttpContextAccessor httpContext, IWebHostEnvironment environment) : base(context, mapper, httpContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
            this.httpContext = httpContext;
            this.environment = environment;
        }
        public async Task<ServiceResponse<EmployeeDTO_ToReturn>> AddEmployee(EmployeeDTO_ToAdd input)
        {
            try
            {

                string fName = input.FormFile.FileName;
                string path = Path.Combine(environment.ContentRootPath, "Images/" + input.FormFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await input.FormFile.CopyToAsync(stream);
                }

                var employeeToAdd = new Employee();
                employeeToAdd.Name = input.Name;
                employeeToAdd.ImageName = input.FormFile.FileName;
                employeeToAdd.Occupation = input.Occupation;

                await context.Employees.AddAsync(employeeToAdd);
                await context.SaveChangesAsync();


                var dto = mapper.Map<EmployeeDTO_ToReturn>(employeeToAdd);
                return ResponseResult.Success<EmployeeDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message);
                return ResponseResult.Failure<EmployeeDTO_ToReturn>(ex.Message);
            }
        }
    }
}