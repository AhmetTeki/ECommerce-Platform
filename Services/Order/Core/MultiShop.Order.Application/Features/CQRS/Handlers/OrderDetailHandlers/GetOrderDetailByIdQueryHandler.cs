using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResult;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IRepository<OrderDetail> _orderDetail;

    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetail)
    {
        _orderDetail = orderDetail;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
    {
        OrderDetail values = await _orderDetail.GetByIdAsync(getOrderDetailByIdQuery.Id);
        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = values.OrderDetailId,
            OrderingId = values.OrderingId,
            ProductAmount = values.ProductAmount,
            ProductId = values.ProductId,
            ProductPrice = values.ProductPrice,
            ProductName = values.ProductName,
            ProductTotalPrice = values.ProductTotalPrice,
        };
    }
}