using BlogApp.WebApi.Models.Domain;


namespace BlogApp.WebApi.Repositories.Interface;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
    Task<IEnumerable<Category>> GetAllAsync();//This is definiton of getAllAsync method
    Task<Category?> GetById(Guid id);
    Task<Category?> UpdateAsync(Category category);
    Task<Category?> DeleteAsync(Guid id);
}
