using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int StateRes { get; set; } = 1;
    }
}
