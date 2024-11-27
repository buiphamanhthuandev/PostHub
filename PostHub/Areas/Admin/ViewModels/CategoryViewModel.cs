using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CategoryType is required!")]
        public int CategoryType_id { get; set; }
    }
}
