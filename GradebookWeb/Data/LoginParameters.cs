using System.ComponentModel.DataAnnotations;

namespace GradebookWeb.Data
{
    public class LoginParameters
    {
        [Required(ErrorMessage = "Unesite email adresu")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Upišite lozinku")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}