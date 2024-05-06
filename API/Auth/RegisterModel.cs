using API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Auth
{
    public class RegisterModel
    {
        //Comment
        //[Required(ErrorMessage = "User Name is required")]
        //public string? Username { get; set; }

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
