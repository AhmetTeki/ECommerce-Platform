using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;

public class UpdateOrderingRequest : IRequest
{
    public int OrderingId { get; set; }

    public string UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; }
}