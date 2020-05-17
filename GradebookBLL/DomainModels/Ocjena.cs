using System.ComponentModel.DataAnnotations;

namespace GradebookBLL.DomainModels
{
    public partial class Ocjena
    {
        public int IdOcjena { get; set; }
        public string Bilješka { get; set; }
        public int? OstvareniBodovi { get; set; }
        [Required]
        public int Ocjena1 { get; set; }
        [Required]
        public int IdProvjera { get; set; }
        [Required]
        public int IdUčenik { get; set; }

        public virtual Provjera IdProvjeraNavigation { get; set; }
        public virtual Korisnik IdUčenikNavigation { get; set; }
    }
}