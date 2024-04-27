using BlogApp.WebApi.Models.Domain;
using BlogApp.WebApi.Models.DTO;
using BlogApp.WebApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogPostsController : ControllerBase
{
    private readonly IBlogPostRepository blogPostRepository;

    public BlogPostsController(IBlogPostRepository blogPostRepository)
    {
        this.blogPostRepository = blogPostRepository;
    }

    //POST: {apiBaseUrl}/api/blogposts
    [HttpPost]
    public async Task<IActionResult> CreateBlogPost([FromBody]CreateBlogPostRequestDto request)
    {
        //Convert DTO to Domain Model
        var blogPost = new BlogPost
        {
            Author = request.Author,
            Content = request.Content,
            CoverImageUrl = request.CoverImageUrl,
            IsVisible = request.IsVisible,
            PublishedDate = request.PublishedDate,
            ShortDescription = request.ShortDescription,
            Title = request.Title,
            UrlHandle = request.UrlHandle
        };

        //Call the repository to create the blog post
        blogPost = await blogPostRepository.CreateAsync(blogPost);

        //Before we return the response, we have to convert the domain model back to a DTO
        var response = new BlogPostDto
        {
            Id = blogPost.Id,
            Author = blogPost.Author,
            Content = blogPost.Content,
            CoverImageUrl = blogPost.CoverImageUrl,
            IsVisible = blogPost.IsVisible,
            PublishedDate = blogPost.PublishedDate,
            ShortDescription = blogPost.ShortDescription,
            Title = blogPost.Title,
            UrlHandle = blogPost.UrlHandle
        };
        return Ok(response);
    }

    //GET: {apiBaseUrl}/api/blogposts
    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
        var blogPosts= await blogPostRepository.GetAllAsync();

        //Convert the domain model to DTO
        var response = new List<BlogPostDto>();
        foreach (var blogPost in blogPosts)
        {
            response.Add(new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                CoverImageUrl = blogPost.CoverImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle
            });
        }
        return Ok(response);
    }
}
