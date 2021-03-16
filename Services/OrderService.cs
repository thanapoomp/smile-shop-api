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
using smileshop_api.DTOs.OrderDTO;
using System.Transactions;

namespace smileshop_api.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductGroupService> _logger;
        private readonly IHttpContextAccessor _httpContext;


        public OrderService(AppDBContext context, IMapper mapper, ILogger<ProductGroupService> logger, IHttpContextAccessor httpContext)
        : base(context, mapper, httpContext)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._httpContext = httpContext;
        }

        public async Task<ServiceResponse<OrderDTO_ToReturn>> AddOrder(OrderDTO_ToAdd input)
        {
            //TODO: Validate input

            var order = new Order();
            order.CreatedBy = GetUsername();
            order.CreatedDate = DateTime.Now;
            order.IsActive = true;
            order.NetTotal = input.NetTotal;
            order.Total = input.Total;
            order.Discount = input.Discount;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderDetails = new List<OrderDetail>();
            foreach (var item in input.OrderDetails)
            {
                orderDetails.Add(new OrderDetail()
                {
                    PricePerUnit = item.PricePerUnit,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    OrderId = order.Id
                });
            }

            await _context.OrderDetails.AddRangeAsync(orderDetails);
            await _context.SaveChangesAsync();

            var resultToReturn = _mapper.Map<OrderDTO_ToReturn>(order);

            return ResponseResult.Success<OrderDTO_ToReturn>(resultToReturn);
        }

    }
}