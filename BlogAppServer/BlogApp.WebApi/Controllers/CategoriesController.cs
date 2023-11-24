using BlogApp.WebApi.Context;
using BlogApp.WebApi.Models.Domain;
using BlogApp.WebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
    {
       //Map DTO to Domain Model
       var category = new Category
       {
           Name = request.Name,
           UrlHandle = request.UrlHandle
       };

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        //Domain model to DTO
        var response = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };


        return Ok(response);
    }
}
