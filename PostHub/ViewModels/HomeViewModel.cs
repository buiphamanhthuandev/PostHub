using Microsoft.Build.ObjectModelRemoting;
using PostHub.Models;
using PostHub.TagHelpers;

namespace PostHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}
