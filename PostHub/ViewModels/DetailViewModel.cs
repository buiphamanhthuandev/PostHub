using PostHub.Models;

namespace PostHub.ViewModels
{
    public class DetailViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Post> PostRelates { get; set; }
        
    }
}
