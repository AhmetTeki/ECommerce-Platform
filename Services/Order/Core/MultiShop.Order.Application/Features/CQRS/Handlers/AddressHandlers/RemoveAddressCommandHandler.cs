using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(RemoveAddressCommand removeAddressCommand)
    {
        Address value=await _addressRepository.GetByIdAsync(removeAddressCommand.Id);
        await _addressRepository.DeleteAsync(value);
    }
}