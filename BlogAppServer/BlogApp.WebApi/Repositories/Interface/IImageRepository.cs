using BlogApp.WebApi.Models.Domain;
using System.Net;

namespace BlogApp.WebApi.Repositories.Interface;

public interface IImageRepository
{
    Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
    Task<IEnumerable<BlogImage>> GetAll();
}
