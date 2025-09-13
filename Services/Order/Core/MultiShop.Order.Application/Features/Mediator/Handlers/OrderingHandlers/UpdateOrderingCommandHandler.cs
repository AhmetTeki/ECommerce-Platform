using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public UpdateOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering values = await _orderingRepository.GetByIdAsync(request.OrderingId);
        values.OrderDate = request.OrderDate;
        values.TotalPrice = request.TotalPrice;
        values.UserId = request.UserId;
        await _orderingRepository.UpdateAsync(values);
    }
}