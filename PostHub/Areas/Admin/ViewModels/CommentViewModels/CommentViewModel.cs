using PostHub.Models;
using PostHub.TagHelpers;

namespace PostHub.Areas.Admin.ViewModels.CommentViewModels
{
    public class CommentViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public string NameSearch { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
