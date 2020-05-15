using System;
using System.ComponentModel.DataAnnotations;

namespace GradebookShared
{
    public class RegisterParameters
    {
        [Required(ErrorMessage = "Unesite svoje ime", AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite svoje prezime", AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Odaberite spol")]
        public string Spol { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }
    }
}