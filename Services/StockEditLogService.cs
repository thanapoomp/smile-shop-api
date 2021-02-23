using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using smileshop_api.DTOs.StockEditLogDTO;
using smileshop_api.Models;
using SmileShopAPI.Data;
using SmileShopAPI.Models;
using SmileShopAPI.Services;
using System.Linq.Dynamic.Core;
using SmileShopAPI.Helpers;

namespace smileshop_api.Services
{
    public class StockEditLogService : ServiceBase, IStockEditLogService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<StockEditLogService> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public StockEditLogService(AppDBContext context, IMapper mapper, ILogger<StockEditLogService> logger, IHttpContextAccessor httpContext) : base(context, mapper, httpContext)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _httpContext = httpContext;
        }

        public async Task<ServiceResponse<StockEditLogDTO_ToReturn>> AddStockEditLog(StockEditLogDTO_ToAdd input)
        {
            var errMsg = "";
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //validate exsist product
                    var product = await GetActiveProductById(input.ProductId);
                    if (product is null)
                    {
                        errMsg = $"Product id:{input.ProductId} not found";
                        _logger.LogError(errMsg);
                        return ResponseResult.Failure<StockEditLogDTO_ToReturn>(errMsg);
                    }

                    //validate stock number
                    var stockAfter = product.Stock + input.AmountNumber;
                    if (stockAfter < 0)
                    {
                        errMsg = $"Invalid amount number input";
                        _logger.LogError(errMsg);
                        return ResponseResult.Failure<StockEditLogDTO_ToReturn>(errMsg);
                    }

                    //create stock edit
                    var stockEditToAdd = new StockEditLog();
                    stockEditToAdd.ProductId = input.ProductId;
                    stockEditToAdd.AmountNumber = input.AmountNumber;
                    stockEditToAdd.AmountBefore = product.Stock;
                    stockEditToAdd.AmountAfter = stockAfter;
                    stockEditToAdd.Remark = input.Remark;
                    stockEditToAdd.CreatedBy = GetUsername();
                    stockEditToAdd.CreatedDate = Now();

                    //update product stock
                    product.Stock = stockAfter;
                    _context.Update(product);
                    await _context.StockEditLogs.AddAsync(stockEditToAdd);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    var dto = _mapper.Map<StockEditLogDTO_ToReturn>(stockEditToAdd);
                    
                    return ResponseResult.Success<StockEditLogDTO_ToReturn>(dto);
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.Message);
                    return ResponseResult.Failure<StockEditLogDTO_ToReturn>(ex.Message);
                }
            }
        }

        public async Task<ServiceResponseWithPagination<List<StockEditLogDTO_ToReturn>>> GetStockEditFilter(StockEditLogDTO_Filter input)
        {
            try
            {
                var queryable = _context.StockEditLogs.Include(x => x.Product).ThenInclude(x => x.ProductGroup).AsQueryable();

                //Filter
                if (input.ProductGroupId.HasValue)
                {
                    queryable = queryable.Where(x => x.Product.ProductGroupId == input.ProductGroupId);
                }
                if (input.ProductId.HasValue)
                {
                    queryable = queryable.Where(x => x.ProductId == input.ProductId);
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
                        return ResponseResultWithPagination.Failure<List<StockEditLogDTO_ToReturn>>(ex.Message);
                    }
                }

                var paginationResult = await _httpContext.HttpContext.InsertPaginationParametersInResponse(queryable, input.RecordsPerPage, input.Page);

                var data = await queryable.Paginate(input).ToListAsync();

                var dto = _mapper.Map<List<StockEditLogDTO_ToReturn>>(data);

                return ResponseResultWithPagination.Success(dto, paginationResult);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseResultWithPagination.Failure<List<StockEditLogDTO_ToReturn>>(ex.Message);
            }
        }

        private async Task<Product> GetActiveProductById(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}