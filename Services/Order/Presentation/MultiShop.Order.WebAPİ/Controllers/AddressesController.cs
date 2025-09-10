using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResult;

namespace MultiShop.Order.WebAPİ.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly GetAddressQueryHandler _getAddressQueryHandler;
    private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
    private readonly CreateAddressCommandHandler _createAddressCommandHandler;
    private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
    private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

    public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
    {
        _getAddressQueryHandler = getAddressQueryHandler;
        _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
        _createAddressCommandHandler = createAddressCommandHandler;
        _updateAddressCommandHandler = updateAddressCommandHandler;
        _removeAddressCommandHandler = removeAddressCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> AddressList()
    {
        List<GetAddressQueryResult> values =await _getAddressQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        GetAddressByIdQueryResult values =await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand addressCommand)
    {
        await _createAddressCommandHandler.Handle(addressCommand);
        return Ok("success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand addressCommand)
    {
        await _updateAddressCommandHandler.Handle(addressCommand);
        return Ok("success");
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveAddress(int id)
    {
        await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
        return Ok("success");
    }
    
}