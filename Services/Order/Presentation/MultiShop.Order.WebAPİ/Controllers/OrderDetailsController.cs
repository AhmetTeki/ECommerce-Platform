using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;

namespace MultiShop.Order.WebAPİ.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
    private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
    private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

    public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
    {
        _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
        _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
    }
    
    [HttpGet]
    public async Task<IActionResult> OrderDetailList()
    {
        List<GetOrderDetailQueryResult> values = await _getOrderDetailQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        GetOrderDetailByIdQueryResult values =await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand orderDetailCommand)
    {
        await _createOrderDetailCommandHandler.Handle(orderDetailCommand);
        return Ok("success");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand orderDetailCommand)
    {
        await _updateOrderDetailCommandHandler.Handle(orderDetailCommand);
        return Ok("success");
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveOrderDetail(int id)
    {
        await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
        return Ok("success");
    }
}