using PostHub.Models;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.ViewModels.ContactViewModels
{
    public class ContactViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public string NameSearch { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
