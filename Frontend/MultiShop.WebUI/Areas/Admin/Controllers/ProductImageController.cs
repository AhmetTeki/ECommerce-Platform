using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.Dto.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/ProductImage")]
public class ProductImageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductImageController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [Route("ProductImageDetail/{id}")]
    [HttpGet]
    public async Task<IActionResult> ProductImageDetail(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/ProductImages/ProductImagesByProductId?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateProductImageDto? values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("ProductImageDetail/{id}")]
    [HttpPost]
    public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(updateProductImageDto);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/ProductImages/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        return View();
    }
}