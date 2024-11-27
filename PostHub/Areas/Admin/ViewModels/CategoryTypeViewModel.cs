using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels
{
    public class CategoryTypeViewModel
    {
        [Required(ErrorMessage ="Name is required!")]
        public string Name { get; set; }
    }
}
