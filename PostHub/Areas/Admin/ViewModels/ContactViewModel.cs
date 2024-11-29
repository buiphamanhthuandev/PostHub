using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Content is required")]
        public string Content { get; set; }
    }
}
