using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Slug { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; }
        public int View { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Required]
        public int Category_id { get; set; }
        public Category Category { get; set; }
        [Required]
        public int User_id { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
