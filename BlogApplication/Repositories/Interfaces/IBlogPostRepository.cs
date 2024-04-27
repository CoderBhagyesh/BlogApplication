using BlogApplication.Models.Domain;

namespace BlogApplication.Repositories.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();

        Task<Post?> GetAsync(int id);

        Task<Post> AddAsync(Post post);

        Task<Post?> UpdateAsync(Post post);

        Task<Post?> DeleteAsync(int id);
    }
}
