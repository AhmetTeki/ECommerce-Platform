using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetail;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetail)
    {
        _orderDetail = orderDetail;
    }

    public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
    {
        await _orderDetail.CreateAsync(new OrderDetail
        {
            ProductAmount = createOrderDetailCommand.ProductAmount,
            ProductId = createOrderDetailCommand.ProductId,
            ProductPrice = createOrderDetailCommand.ProductPrice,
            ProductName = createOrderDetailCommand.ProductName,
            ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
            OrderingId = createOrderDetailCommand.OrderingId,
        });
    }
}