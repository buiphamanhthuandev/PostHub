using PostHub.Models;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.ViewModels.SubscribeViewModels
{
    public class SubscribeViewModel
    {
        public IEnumerable<Subscribe> Subscribes { get; set; }
        public string NameSearch { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
