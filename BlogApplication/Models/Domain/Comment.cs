using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int BlogPostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
