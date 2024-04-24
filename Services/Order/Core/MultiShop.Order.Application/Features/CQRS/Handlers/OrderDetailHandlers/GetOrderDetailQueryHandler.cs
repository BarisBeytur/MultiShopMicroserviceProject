using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {

        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return orderDetails.Select(x => new GetOrderDetailQueryResult
            {
                Id = x.Id,
                OrderingId = x.OrderingId,
                ProductId = x.ProductId,
                ProductAmount = x.ProductAmount,
                ProductPrice = x.ProductPrice,
                ProductName = x.ProductName,
                ProductTotalPrice = x.ProductTotalPrice,
            }).ToList();
        }
    }
}
