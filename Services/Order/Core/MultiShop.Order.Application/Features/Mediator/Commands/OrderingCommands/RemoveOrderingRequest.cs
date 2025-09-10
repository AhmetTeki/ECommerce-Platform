using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;

public class RemoveOrderingRequest: IRequest
{
    public int Id { get; set; }
    
    public RemoveOrderingRequest(int id)
    {
        Id = id;
    }
}