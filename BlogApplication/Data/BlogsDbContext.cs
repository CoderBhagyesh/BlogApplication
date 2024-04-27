﻿using BlogApplication.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Data
{
    public class BlogsDbContext : DbContext
    {
        public BlogsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users {  get; set; }

    }
}