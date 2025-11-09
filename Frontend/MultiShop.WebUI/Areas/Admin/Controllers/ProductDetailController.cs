using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/ProductDetail")]
public class ProductDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [Route("UpdateProductDetail/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProductDetail(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/ProductDetails/GetProductDetailByProductId?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            UpdateProductDetailDto? values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("UpdateProductDetail/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(updateProductDetailDto);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/ProductDetails/" , stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        return View();
    }
}