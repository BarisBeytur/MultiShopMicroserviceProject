﻿using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Id = orderDetail.Id,
                OrderingId = orderDetail.OrderingId,
                ProductId = orderDetail.ProductId,
                ProductAmount = orderDetail.ProductAmount,
                ProductPrice = orderDetail.ProductPrice,
                ProductName = orderDetail.ProductName,
                ProductTotalPrice = orderDetail.ProductTotalPrice,
            };
        }

    }
}
