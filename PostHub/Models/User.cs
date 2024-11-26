using Microsoft.AspNetCore.Identity;

namespace PostHub.Models
{
    public class User : IdentityUser
    {
        public string DateOfBirth { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public int IsActive { get; set; } = 1;

        public string FullName { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
