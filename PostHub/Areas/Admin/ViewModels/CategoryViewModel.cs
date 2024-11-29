using PostHub.Models;
using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CategoryType is required!")]
        [Display(Name ="CategoryType")]
        public int CategoryTypeId { get; set; }

    }
}
