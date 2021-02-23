using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using smileshop_api.DTOs.ProductDTO;
using smileshop_api.Models;
using SmileShopAPI.Data;
using SmileShopAPI.Models;
using SmileShopAPI.Services;
using System.Linq.Dynamic.Core;
using SmileShopAPI.Helpers;

namespace smileshop_api.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public ProductService(AppDBContext context, IMapper mapper, ILogger<ProductService> logger, IHttpContextAccessor httpContext)
        : base(context, mapper, httpContext)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._httpContext = httpContext;
        }

        public async Task<ServiceResponse<ProductDTO_ToReturn>> AddProduct(ProductDTO_ToAdd input)
        {
            var errMsg = "";

            //validate productgroup
            var productGroupExsist = await GetActiveProductGroupById(input.ProductGroupId);
            if (productGroupExsist is null)
            {
                errMsg = $"product group id: {input.ProductGroupId} not found";
                _logger.LogError(errMsg);
                return ResponseResult.Failure<ProductDTO_ToReturn>(errMsg);
            }

            try
            {
                var productToAdd = new Product();
                productToAdd.Name = input.Name;
                productToAdd.ProductGroupId = input.ProductGroupId;
                productToAdd.Price = input.Price;
                productToAdd.Stock = input.Stock;
                productToAdd.ImageUrl = "";
                productToAdd.IsActive = true;
                productToAdd.CreatedBy = GetUsername();
                productToAdd.CreatedDate = Now();
                productToAdd.UpdatedBy = GetUsername();
                productToAdd.UpdatedDate = Now();
                await _context.Products.AddAsync(productToAdd);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ProductDTO_ToReturn>(productToAdd);
                return ResponseResult.Success<ProductDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<ProductDTO_ToReturn>(ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductDTO_ToReturn>> DeleteProduct(int id)
        {
            var errMsg = "";

            //validate exsist product
            var productToDelete = await GetActiveProductById(id);
            if (productToDelete is null)
            {
                errMsg = $"product id: {id} not found";
                return ResponseResult.Failure<ProductDTO_ToReturn>(errMsg);
            }

            try
            {
                productToDelete.IsActive = false;
                productToDelete.UpdatedBy = GetUsername();
                productToDelete.UpdatedDate = Now();
                _context.Update(productToDelete);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ProductDTO_ToReturn>(productToDelete);
                return ResponseResult.Success<ProductDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<ProductDTO_ToReturn>(ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductDTO_ToReturn>> EditProduct(ProductDTO_ToAdd input, int id)
        {
            var errMsg = "";

            //validate productgroup
            var productGroupExsist = await GetActiveProductGroupById(input.ProductGroupId);
            if (productGroupExsist is null)
            {
                errMsg = $"product group id: {input.ProductGroupId} not found";
                _logger.LogError(errMsg);
                return ResponseResult.Failure<ProductDTO_ToReturn>(errMsg);
            }

            //validate exsist product
            var productToUpdate = await GetActiveProductById(id);
            if (productToUpdate is null)
            {
                errMsg = $"product id: {id} not found";
                return ResponseResult.Failure<ProductDTO_ToReturn>(errMsg);
            }

            //update product
            try
            {
                productToUpdate.Name = input.Name;
                productToUpdate.Price = input.Price;
                productToUpdate.ImageUrl = input.ImageUrl;
                productToUpdate.ProductGroupId = input.ProductGroupId;
                productToUpdate.UpdatedBy = GetUsername();
                productToUpdate.UpdatedDate = Now();
                _context.Update(productToUpdate);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ProductDTO_ToReturn>(productToUpdate);
                return ResponseResult.Success<ProductDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<ProductDTO_ToReturn>(ex.Message);
            }
        }

        public async Task<ServiceResponse<List<ProductDTO_ToReturn>>> GetActiveProducts()
        {
            try
            {
                var result = await _context.Products
                .Include(x => x.ProductGroup)
                .Where(x => x.IsActive == true)
                .ToListAsync();

                var dto = _mapper.Map<List<ProductDTO_ToReturn>>(result);
                return ResponseResult.Success<List<ProductDTO_ToReturn>>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<List<ProductDTO_ToReturn>>(ex.Message);
            }
        }

        public async Task<ServiceResponse<List<ProductDTO_ToReturn>>> GetAllProducts()
        {
            try
            {
                var result = await _context.Products
                .Include(x => x.ProductGroup)
                .ToListAsync();

                var dto = _mapper.Map<List<ProductDTO_ToReturn>>(result);
                return ResponseResult.Success<List<ProductDTO_ToReturn>>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<List<ProductDTO_ToReturn>>(ex.Message);
            }
        }

        public async Task<ServiceResponse<List<ProductDTO_ToReturn>>> GetByProductGroupId(int productGroupId)
        {
            try
            {
                //validate exsist product
                var result = await _context.Products.Where(x => x.ProductGroupId == productGroupId && x.IsActive == true).ToListAsync();

                var dto = _mapper.Map<List<ProductDTO_ToReturn>>(result);
                return ResponseResult.Success<List<ProductDTO_ToReturn>>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<List<ProductDTO_ToReturn>>(ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductDTO_ToReturn>> GetProductById(int id)
        {
            var errMsg = "";
            try
            {
                //validate exsist product
                var product = await GetActiveProductById(id);
                if (product is null)
                {
                    errMsg = $"product id: {id} not found";
                    return ResponseResult.Failure<ProductDTO_ToReturn>(errMsg);
                }

                var dto = _mapper.Map<ProductDTO_ToReturn>(product);
                return ResponseResult.Success<ProductDTO_ToReturn>(dto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResult.Failure<ProductDTO_ToReturn>(ex.Message);
            }
        }

        public async Task<ServiceResponseWithPagination<List<ProductDTO_ToReturn>>> GetProductFilter(ProductDTO_Filter input)
        {
            try
            {
                var queryable = _context.Products.Include(x => x.ProductGroup).AsQueryable();

                //Filter
                if (!string.IsNullOrWhiteSpace(input.Name))
                {
                    queryable = queryable.Where(x => x.Name.Contains(input.Name));
                }
                if (input.IsShowInActive.HasValue)
                {
                    if (input.IsShowInActive.Value == false)
                    {
                        queryable = queryable.Where(x => x.IsActive ==true);
                    }
                }else {
                    queryable = queryable.Where(x => x.IsActive ==true);
                }
                if (input.ProductGroupId.HasValue)
                {
                    queryable = queryable.Where(x => x.ProductGroupId == input.ProductGroupId);
                }

                //Ordering
                if (!string.IsNullOrWhiteSpace(input.OrderingField))
                {
                    try
                    {
                        queryable = queryable.OrderBy($"{input.OrderingField} {(input.AscendingOrder ? "asc" : "desc")}");
                    }
                    catch (System.Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        return ResponseResultWithPagination.Failure<List<ProductDTO_ToReturn>>(ex.Message);
                    }
                }

                var paginationResult = await _httpContext.HttpContext.InsertPaginationParametersInResponse(queryable, input.RecordsPerPage, input.Page);

                var data = await queryable.Paginate(input).ToListAsync();

                var dto = _mapper.Map<List<ProductDTO_ToReturn>>(data);

                return ResponseResultWithPagination.Success(dto, paginationResult);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResultWithPagination.Failure<List<ProductDTO_ToReturn>>(ex.Message);
            }
        }

        private async Task<Product> GetActiveProductById(int id)
        {
            return await _context.Products
            .Include(x => x.ProductGroup)
            .Where(x => x.Id == id && x.IsActive == true)
            .FirstOrDefaultAsync();
        }

        private async Task<ProductGroup> GetActiveProductGroupById(int id)
        {
            return await _context.ProductGroups.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}