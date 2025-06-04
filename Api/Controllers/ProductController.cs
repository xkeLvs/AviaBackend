using Microsoft.AspNetCore.Mvc;
using AviaBackend.Application.DTOs.Product;
using AviaBackend.Application.Interfaces;
using AviaBackend.Domain.Entities;

namespace AviaBackend.Api.Controllers;

// /YourProject.Api/Controllers/ProductsController.cs
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ICrudAppService<Product, ProductDto, CreateProductDto, UpdateProductDto> _productService;

    public ProductsController(ICrudAppService<Product, ProductDto, CreateProductDto, UpdateProductDto> productService)
    {
        _productService = productService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _productService.GetAsync(id, includes: x => x.Category);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync(includes: x => x.Category);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto input)
    {
        var product = await _productService.CreateAsync(input);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductDto input)
    {
        await _productService.UpdateAsync(id, input);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}


