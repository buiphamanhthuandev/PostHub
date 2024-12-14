using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels.PostViewModels
{
    public class PostFormViewModel
    {
        [Required(ErrorMessage = "Title is Required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is Required.")]
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Category is Required.")]
        public int CategoryId { get; set; }
    }
}
