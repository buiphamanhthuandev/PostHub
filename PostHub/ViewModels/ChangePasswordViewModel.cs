using System.ComponentModel.DataAnnotations;

namespace PostHub.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and max {1} characters!")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "ConfirmPassword does not watch")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password Required.")]
        public string ConfirmPassword { get; set; }
    }
}
