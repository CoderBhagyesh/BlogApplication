using BlogApplication.Data;
using BlogApplication.Models.Domain;
using BlogApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Repositories.Implementations
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogsDbContext blogsDbContext;

        public BlogPostRepository(BlogsDbContext blogsDbContext) 
        {
            this.blogsDbContext = blogsDbContext;
        }

        public async Task<Post> AddAsync(Post post)
        {
            await blogsDbContext.AddAsync(post);
            await blogsDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeleteAsync(int id)
        {
            var existingBlog = await blogsDbContext.Posts.FindAsync(id);
            if (existingBlog != null)
            {
                blogsDbContext.Remove(existingBlog);
                await blogsDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await blogsDbContext.Posts.ToListAsync();    
        }

        public async Task<Post?> GetAsync(int id)
        {
            return await blogsDbContext.Posts.FirstOrDefaultAsync(b => b.PostId == id);
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            var existingBlog = await blogsDbContext.Posts.Include(x=> x.UserId)
                .FirstOrDefaultAsync(x => x.PostId == post.PostId);

            if (existingBlog != null)
            {
                existingBlog.PostId = post.PostId;
                existingBlog.Title = post.Title;
                existingBlog.Content = post.Content;
                existingBlog.ShortDescription = post.ShortDescription;
                existingBlog.Author = post.Author;
                existingBlog.FeaturedImageUrl = post.FeaturedImageUrl;
                existingBlog.CreatedAt = post.CreatedAt;
                existingBlog.UpdatedAt = post.UpdatedAt;

                await blogsDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }
    }
}
