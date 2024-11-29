using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public int View { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int State { get; set; } = 1;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
