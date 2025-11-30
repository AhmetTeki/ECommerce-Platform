using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        List<ResultContactDto> values = await _contactService.GetAllContactAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(string id)
    {
        GetByIdContactDto value = await _contactService.GetByIdContactAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        await _contactService.CreateContactAsync(createContactDto);
        return Ok("Success");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(string id)
    {
        await _contactService.DeleteContactAsync(id);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactDto createContactDto)
    {
        await _contactService.UpdateContactAsync(createContactDto);
        return Ok("Success");
    }
}