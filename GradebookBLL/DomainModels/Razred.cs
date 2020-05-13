using System.Collections.Generic;

namespace GradebookBLL.DomainModels
{
    public partial class Razred
    {
        public Razred()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int IdRazred { get; set; }
        public string KraticaOdjel { get; set; }
        public int IdRazrednik { get; set; }
        public int GodinaRazreda { get; set; }

        public virtual GodinaRazreda GodinaRazredaNavigation { get; set; }
        public virtual Korisnik IdRazrednikNavigation { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}