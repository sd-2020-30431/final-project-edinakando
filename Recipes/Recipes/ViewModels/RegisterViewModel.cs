using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recipes.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name Required")]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public String Password { get; set; }

        public UserType Type { get; set; }
    }

    public enum UserType
    {
        regular,
        chef
    }
}
