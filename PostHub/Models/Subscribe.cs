using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
