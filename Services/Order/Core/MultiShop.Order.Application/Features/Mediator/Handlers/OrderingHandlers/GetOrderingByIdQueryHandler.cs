using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public GetOrderingByIdQueryHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        Ordering values = await _orderingRepository.GetByIdAsync(request.Id);
        return new GetOrderingByIdQueryResult
        {
            OrderingId = values.OrderingId,
            UserId = values.UserId,
            TotalPrice = values.TotalPrice,
            OrderDate = values.OrderDate
        };
    }
}