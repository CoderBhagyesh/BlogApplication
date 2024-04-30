namespace BlogApplication.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; } 
        public string FeaturedImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
