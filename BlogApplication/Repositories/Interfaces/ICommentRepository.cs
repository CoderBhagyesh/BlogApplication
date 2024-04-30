using BlogApplication.Models.Domain;

namespace BlogApplication.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment blogPostComment);
        Task<IEnumerable<Comment>> GetCommentsByBlogIdAsync(int blogPostId);
    }
}
