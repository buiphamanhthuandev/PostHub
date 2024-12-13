using PostHub.Models;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.ViewModels.UserViewModel
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public string NameSearch { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
