using BlogApp.WebApi.Models.Domain;

namespace BlogApp.WebApi.Repositories.Interface;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
}
