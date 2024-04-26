using BlogApp.WebApi.Context;
using BlogApp.WebApi.Models.Domain;
using BlogApp.WebApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Category?> DeleteAsync(Guid id)
    {
        var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        if(existingCategory is null)
        {
            return null;
        }

        _context.Categories.Remove(existingCategory);
        await _context.SaveChangesAsync();
        return existingCategory;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
       return await _context.Categories.ToListAsync();//Gets all the categories from the database
    }

    public async Task<Category?> GetById(Guid id)
    {
        return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Category?> UpdateAsync(Category category)
    {
       var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == category.Id);

        if (existingCategory is not null)
        {
           _context.Entry(existingCategory).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return category;
        }
        return null;
    }   
}
