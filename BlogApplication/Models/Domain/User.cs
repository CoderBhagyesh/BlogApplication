using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models.Domain
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // Navigation Property
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
