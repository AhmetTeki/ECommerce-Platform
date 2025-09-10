using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _orderDetail;

    public GetOrderDetailQueryHandler(IRepository<OrderDetail> orderDetail)
    {
        _orderDetail = orderDetail;
    }
    
    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        List<OrderDetail> values= await _orderDetail.GetAllAsync();
        return values.Select(x => new GetOrderDetailQueryResult
        {
            OrderDetailId = x.OrderDetailId,
            OrderingId = x.OrderingId,
            ProductAmount = x.ProductAmount,
            ProductId = x.ProductId,
            ProductPrice = x.ProductPrice,
            ProductName = x.ProductName,
            ProductTotalPrice = x.ProductTotalPrice,
        }).ToList();
    }
}