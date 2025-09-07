using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(UpdateAddressCommand updateAddressCommand)
    {
        Address values = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressId);
        values.City = updateAddressCommand.City;
        values.Detail = updateAddressCommand.Detail;
        values.District = updateAddressCommand.District;
        values.UserId = updateAddressCommand.UserId;
        await _addressRepository.UpdateAsync(values);
    }
}