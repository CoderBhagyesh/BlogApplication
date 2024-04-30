namespace BlogApplication.Models.ViewModels
{
    public class BlogDetailsViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Author { get; set; }
        public string CommentDescription { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
