using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/OfferDiscount")]
public class OfferDiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOfferDsicountServices _offerDsicountServices;

    public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDsicountServices offerDsicountServices)
    {
        _httpClientFactory = httpClientFactory;
        _offerDsicountServices = offerDsicountServices;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
       List<ResultOfferDiscountDto> values = await _offerDsicountServices.GetAllOfferDiscountAsync();
       return View(values);
    }

    [HttpGet]
    [Route("CreateOfferDiscount")]
    public IActionResult CreateOfferDiscount()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateOfferDiscount")]
    public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
    {
       await _offerDsicountServices.CreateOfferDiscountAsync(createOfferDiscountDto);
       return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
    }

    [Route("DeleteOfferDiscount/{id}")]
    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
       await _offerDsicountServices.DeleteOfferDiscountAsync(id);
       return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
    }

    [Route("UpdateOfferDiscount/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateOfferDiscount(string id)
    {
       UpdateOfferDiscountDto values = await _offerDsicountServices.GetByIdOfferDiscountAsync(id);
       return View(values);
    }

    [Route("UpdateOfferDiscount/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
       await _offerDsicountServices.UpdateOfferDiscountAsync(updateOfferDiscountDto);
       return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
    }
}