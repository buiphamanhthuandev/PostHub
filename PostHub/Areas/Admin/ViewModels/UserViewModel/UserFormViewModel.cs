using System.ComponentModel.DataAnnotations;

namespace PostHub.Areas.Admin.ViewModels.UserViewModel
{
    public class UserFormViewModel
    {
        [Required(ErrorMessage ="Full Name is Required!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is Required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Role is Required!")]
        public string Role { get; set; }
    }
}
