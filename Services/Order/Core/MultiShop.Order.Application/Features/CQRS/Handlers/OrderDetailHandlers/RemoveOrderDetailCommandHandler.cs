using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class RemoveOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetail;

    public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> orderDetail)
    {
        _orderDetail = orderDetail;
    }

    public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
    {
        OrderDetail value=await _orderDetail.GetByIdAsync(removeOrderDetailCommand.Id);
        await _orderDetail.DeleteAsync(value);
    }
}