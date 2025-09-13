using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.WebAPİ.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> OrderingList()
    {
        List<GetOrderingQueryResult> values = await _mediator.Send(new GetOrderingQuery());
        return Ok(values);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        GetOrderingByIdQueryResult values = await _mediator.Send(new GetOrderingByIdQuery(id));
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
    {
        await _mediator.Send(createOrderingCommand);
        return Ok("success");
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveOrdering(int id)
    {
        await _mediator.Send(new RemoveOrderingCommand(id));
        return Ok("success");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
    {
        await _mediator.Send(updateOrderingCommand);
        return Ok("success");
    }
}