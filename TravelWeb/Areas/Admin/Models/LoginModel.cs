using System.ComponentModel.DataAnnotations;

namespace TravelWeb.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please, Enter your name!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please, Enter your password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}