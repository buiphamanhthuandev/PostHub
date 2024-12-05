using Microsoft.Build.ObjectModelRemoting;
using PostHub.Models;
using PostHub.TagHelpers;

namespace PostHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Post> PostTopViews { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
