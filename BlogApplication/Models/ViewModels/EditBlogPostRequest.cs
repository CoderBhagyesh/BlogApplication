namespace BlogApplication.Models.ViewModels
{
    public class EditBlogPostRequest
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Related Fields to the User Table
        public int UserId { get; set; }
    }
}
