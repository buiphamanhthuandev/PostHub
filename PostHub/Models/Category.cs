using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int State { get; set; } = 1;
        [Required]
        public int CategoryType_id { get; set; }
        public CategoryType CategoryType { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
