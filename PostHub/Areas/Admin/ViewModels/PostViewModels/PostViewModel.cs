using PostHub.Models;
using PostHub.TagHelpers;

namespace PostHub.Areas.Admin.ViewModels.PostViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public string NameSearch { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
