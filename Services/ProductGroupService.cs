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

namespace smileshop_api.Services
{
    public class ProductGroupService : ServiceBase, IProductGroupService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductGroupService> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public ProductGroupService(AppDBContext context, IMapper mapper, ILogger<ProductGroupService> logger, IHttpContextAccessor httpContext) : base(context, mapper, httpContext)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._httpContext = httpContext;
        }

        
        public async Task<ServiceResponse<ProductGroupDTO_ToReturn>> AddProductGroup(ProductGroupDTO_ToAdd input)
        {
            try
            {
                var productGroupToAdd = new ProductGroup();
                productGroupToAdd.Name = input.Name;
                productGroupToAdd.CreatedBy = GetUsername();
                productGroupToAdd.CreatedDate = DateTime.Now;
                productGroupToAdd.UpdatedBy = GetUsername();
                productGroupToAdd.UpdatedDate = DateTime.Now;
                productGroupToAdd.IsActive = true;
                await _context.ProductGroups.AddAsync(productGroupToAdd);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ProductGroupDTO_ToReturn>(productGroupToAdd);
                return ResponseResult.Success<ProductGroupDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                return ResponseResult.Failure<ProductGroupDTO_ToReturn>(ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductGroupDTO_ToReturn>> DeleteProductGroup(int id)
        {
            try
            {
                var productGroupToDelete = await GetActiveProductGroupById(id);
                if (productGroupToDelete is null)
                {
                    return ResponseResult.Failure<ProductGroupDTO_ToReturn>($"ProductGroup id:{id} not found");
                }

                productGroupToDelete.IsActive = false;
                productGroupToDelete.UpdatedDate = DateTime.Now;
                productGroupToDelete.UpdatedBy = GetUsername();
                _context.Update(productGroupToDelete);
                await _context.SaveChangesAsync();

                var dtoToReturn = _mapper.Map<ProductGroupDTO_ToReturn>(productGroupToDelete);

                return ResponseResult.Success<ProductGroupDTO_ToReturn>(dtoToReturn);
            }
            catch (System.Exception ex)
            {
                return ResponseResult.Failure<ProductGroupDTO_ToReturn>(ex.Message);
                throw;
            }
        }

        public async Task<ServiceResponse<ProductGroupDTO_ToReturn>> EditProductGroup(ProductGroupDTO_ToAdd input, int id)
        {
            var productGroup = await GetActiveProductGroupById(id);
            try
            {
                if (productGroup is null)
                {
                    return ResponseResult.Failure<ProductGroupDTO_ToReturn>($"ProductGroup id:{id} not found");
                }

                productGroup.Name = input.Name;
                productGroup.UpdatedBy = GetUsername();
                productGroup.UpdatedDate = DateTime.Now;

                _context.Update(productGroup);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ProductGroupDTO_ToReturn>(productGroup);
                return ResponseResult.Success<ProductGroupDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                return ResponseResult.Failure<ProductGroupDTO_ToReturn>(ex.Message);
                throw;
            }
        }

        public async Task<ServiceResponse<List<ProductGroupDTO_ToReturn>>> GetActiveProductGroups()
        {
            var productGroupList = await _context.ProductGroups.Where(x => x.IsActive == true).ToListAsync();
            var dto = _mapper.Map<List<ProductGroupDTO_ToReturn>>(productGroupList);
            return ResponseResult.Success<List<ProductGroupDTO_ToReturn>>(dto);
        }

        public async Task<ServiceResponse<List<ProductGroupDTO_ToReturn>>> GetAllProductGroups()
        {
            var productGroupList = await _context.ProductGroups.ToListAsync();
            var dto = _mapper.Map<List<ProductGroupDTO_ToReturn>>(productGroupList);
            return ResponseResult.Success<List<ProductGroupDTO_ToReturn>>(dto);
        }

        public async Task<ServiceResponse<ProductGroupDTO_ToReturn>> GetProductGroupById(int id)
        {
            var productGroup = await GetActiveProductGroupById(id);
            try
            {
                if (productGroup is null)
                {
                    return ResponseResult.Failure<ProductGroupDTO_ToReturn>($"ProductGroup id:{id} not found");
                }

                var dto = _mapper.Map<ProductGroupDTO_ToReturn>(productGroup);
                return ResponseResult.Success<ProductGroupDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                return ResponseResult.Failure<ProductGroupDTO_ToReturn>(ex.Message);
                throw;
            }
        }

        public async Task<ServiceResponseWithPagination<List<ProductGroupDTO_ToReturn>>> GetProductGroupFilter(ProductGroupDTO_Filter input)
        {
            var queryable = _context.ProductGroups.AsQueryable();

            //Filter
            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                queryable = queryable.Where(x => x.Name.Contains(input.Name));
            }

            //Ordering
            if (!string.IsNullOrWhiteSpace(input.OrderingField))
            {
                try
                {
                    queryable = queryable.OrderBy($"{input.OrderingField} {(input.AscendingOrder ? "asc" : "desc")}");
                }
                catch (System.Exception)
                {
                    return ResponseResultWithPagination.Failure<List<ProductGroupDTO_ToReturn>>($"Ordering field name:{input.OrderingField} not found");
                }
            }

            var paginationResult = await _httpContext.HttpContext.InsertPaginationParametersInResponse(queryable, input.RecordsPerPage, input.Page);

            var data = await queryable.Paginate(input).ToListAsync();

            var dto = _mapper.Map<List<ProductGroupDTO_ToReturn>>(data);

            return ResponseResultWithPagination.Success(dto, paginationResult);
        }

        private async Task<ProductGroup> GetActiveProductGroupById(int id)
        {
            return await _context.ProductGroups.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
        }

    }
}