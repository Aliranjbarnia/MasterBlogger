using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MB.Presentation.MVC.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter UserName")]
        public string Username { get; set; }



        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Please Enter Alpha Charecter & [A-Z]")]
        public string Password { get; set; }



        [Required(ErrorMessage = "Please Enter Password")]
        [Compare(nameof(Password), ErrorMessage = "Password And Confirmed Is Not Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
