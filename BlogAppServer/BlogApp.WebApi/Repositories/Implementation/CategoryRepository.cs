using BlogApp.WebApi.Context;
using BlogApp.WebApi.Models.Domain;
using BlogApp.WebApi.Repositories.Interface;

namespace BlogApp.WebApi.Repositories.Implementation;

public class CategoryRepository: ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

 
    public async Task<Category>CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

}
