using LemonDrop.Website.Mvc.Enums;
using System.ComponentModel.DataAnnotations;

namespace LemonDrop.Website.Mvc.ViewModels
{
    public class RegistrationInfoVM
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be longer than 5 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string EncryptPassword => Password;
        public string FullName => $"{LastName} {FirstName}";
    }
}