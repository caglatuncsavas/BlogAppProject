using BlogApp.WebApi.Models.Domain;

namespace BlogApp.WebApi.Repositories.Interface;
public interface IBlogPostRepository
{
    Task<BlogPost> CreateAsync(BlogPost blogPost);
    Task<IEnumerable<BlogPost>> GetAllAsync();
}
