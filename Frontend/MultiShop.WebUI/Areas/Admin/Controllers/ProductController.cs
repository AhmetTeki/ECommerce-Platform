using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Product")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Products");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultProductDto>? values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View();
    }
    
    [Route("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Products/ProductListWithCategory");

        if (response.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            List<ResultProductWithCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:7099/api/Categories");
        string jsonData = await response.Content.ReadAsStringAsync();
        List<ResultCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

        CreateProductDto model = new CreateProductDto
        {
            Categories = values
        };
        return View(model);
    }

    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto product)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(product);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:7099/api/Products", stringContent);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:7099/api/Products/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateProduct/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        HttpClient? client2 = _httpClientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync($"http://localhost:7099/api/Products/{id}");

        HttpResponseMessage response2 = await client2.GetAsync("http://localhost:7099/api/Categories");

        if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
        {
            string jsonData = await response.Content.ReadAsStringAsync();
            string jsonDataCategory = await response2.Content.ReadAsStringAsync();

            UpdateProductDto? values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            List<ResultCategoryDto>? valuesCategory =
                JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);


            var model = new UpdateProductDto
            {
                Categories = valuesCategory,
                ProductDescription = values?.ProductDescription,
                CategoryId = values?.CategoryId,
                ProductName = values?.ProductName,
                ProductImageUrl = values?.ProductImageUrl,
                ProductPrice = values.ProductPrice,
                ProductId = values.ProductId,
            };
            return View(model);
        }

        return View();
    }

    [Route("UpdateProduct/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto product)
    {
        HttpClient? client = _httpClientFactory.CreateClient();
        string jsonDataa = JsonConvert.SerializeObject(product);
        StringContent stringContent = new StringContent(jsonDataa, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PutAsync("http://localhost:7099/api/Products/", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        return View();
    }
}