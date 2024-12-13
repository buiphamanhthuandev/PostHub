using PostHub.Models;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string NameSearch {  get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
