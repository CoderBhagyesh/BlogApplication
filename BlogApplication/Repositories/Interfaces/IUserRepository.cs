using Microsoft.AspNetCore.Identity;

namespace BlogApplication.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
