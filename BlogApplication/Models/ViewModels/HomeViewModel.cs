using BlogApplication.Models.Domain;

namespace BlogApplication.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> BlogPosts { get; set; }
    }
}
