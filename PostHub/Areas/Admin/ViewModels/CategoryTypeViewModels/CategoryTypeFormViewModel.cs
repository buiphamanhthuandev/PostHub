using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels.CategoryTypeViewModels
{
    public class CategoryTypeFormViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
