﻿using BlogApp.WebApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.WebApi.Context;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BlogImage> BlogImages { get; set; }
}
