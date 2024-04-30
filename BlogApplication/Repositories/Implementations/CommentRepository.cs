using BlogApplication.Data;
using BlogApplication.Models.Domain;
using BlogApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogsDbContext dbContext;

        public CommentRepository(BlogsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Comment> AddAsync(Comment blogPostComment)
        {
            await dbContext.Comments.AddAsync(blogPostComment);
            await dbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByBlogIdAsync(int blogPostId)
        {
            return await dbContext.Comments.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
