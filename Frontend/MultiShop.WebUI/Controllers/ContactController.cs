using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto dto)
    {
        dto.IsRead=false;
        dto.SendDate = DateTime.Now;
        await _contactService.CreateContactAsync(dto);
        return RedirectToAction("Index", "Default");
    }
}