using PostHub.Models;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.ViewModels.CategoryTypeViewModels
{
    public class CategoryTypeViewModel
    {
        public IEnumerable<CategoryType> CategoryTypes { get; set; }
        public string NameSearch { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
