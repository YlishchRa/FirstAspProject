using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class User
    {
        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(50, ErrorMessage = "Too long name")]
        public string Name {get; set;}

        [RegularExpression(@"^[a-zA-Z0-9._]+@[a-zA-Z0-9]+\.[a-zA-Z]+$", ErrorMessage = "Email can contain onlu numbers and symbols")]
        public string Email { get; set;}
        [MinLength(6, ErrorMessage = "Too short password")]
        public string Password { get; set; }
    }
}
