using BlogApp.WebApi.Context;
using BlogApp.WebApi.Models.Domain;
using BlogApp.WebApi.Models.DTO;
using BlogApp.WebApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
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

        await categoryRepository.CreateAsync(category);

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
