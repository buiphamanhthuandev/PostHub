using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; } = 1;

        public int CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

}
