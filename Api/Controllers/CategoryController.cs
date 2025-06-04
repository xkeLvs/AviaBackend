
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AviaBackend.Application.DTOs.Category;
using AviaBackend.Application.Interfaces;
using AviaBackend.Domain.Entities;


namespace AviaBackend.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICrudAppService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto> _categoryService;

    public CategoriesController(ICrudAppService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto> categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var category = await _categoryService.GetAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto input)
    {
        var category = await _categoryService.CreateAsync(input);
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateCategoryDto input)
    {
        await _categoryService.UpdateAsync(id, input);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }
}
