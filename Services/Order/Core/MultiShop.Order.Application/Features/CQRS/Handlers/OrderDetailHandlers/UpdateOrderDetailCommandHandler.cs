using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetail;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetail)
    {
        _orderDetail = orderDetail;
    }

    public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        OrderDetail values = await _orderDetail.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
        values.ProductAmount = updateOrderDetailCommand.ProductAmount;
        values.ProductId = updateOrderDetailCommand.ProductId;
        values.ProductPrice = updateOrderDetailCommand.ProductPrice;
        values.ProductName = updateOrderDetailCommand.ProductName;
        values.OrderingId = updateOrderDetailCommand.OrderingId;
        values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
        await _orderDetail.UpdateAsync(values);
    }
}