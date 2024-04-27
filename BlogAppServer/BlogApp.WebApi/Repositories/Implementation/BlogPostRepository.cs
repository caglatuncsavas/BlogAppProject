using BlogApp.WebApi.Context;
using BlogApp.WebApi.Models.Domain;
using BlogApp.WebApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.WebApi.Repositories.Implementation;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly AppDbContext _context;
    public BlogPostRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<BlogPost> CreateAsync(BlogPost blogPost)
    {
        await _context.BlogPosts.AddAsync(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
       return await _context.BlogPosts.ToListAsync();
    }
}
