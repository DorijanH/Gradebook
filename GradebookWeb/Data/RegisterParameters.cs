using System.ComponentModel.DataAnnotations;

namespace GradebookWeb.Data
{
    public class RegisterParameters
    {
        [Required(ErrorMessage = "Unesite svoje ime", AllowEmptyStrings = false)]
        [Display(Name = "Ime korisnika")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite svoje prezime", AllowEmptyStrings = false)]
        [Display(Name = "Prezime korisnika")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Odaberite spol")]
        [Display(Name = "Spol")]
        public string Spol { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja korisnika")]
        public string DoB { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda lozinke")]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }
    }
}