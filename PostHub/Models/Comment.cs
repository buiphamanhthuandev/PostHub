using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int User_id { get; set; }
        public User User { get; set; }
        [Required]
        public int Post_id { get; set; }
        public Post Post { get; set; }

    }
}
