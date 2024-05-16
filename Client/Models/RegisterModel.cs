
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string? LastName { get; set; }

        public string? Avatar {  get; set; }
        [Required(ErrorMessage = "Agency is required")]
        public Agency? Agency { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
