using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int StateRes { get; set; } = 1;
    }
}
