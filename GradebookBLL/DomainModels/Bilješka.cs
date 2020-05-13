using System;

namespace GradebookBLL.DomainModels
{
    public partial class Bilješka
    {
        public int IdBilješka { get; set; }
        public string Opis { get; set; }
        public DateTime? Datum { get; set; }
        public int ZabilježioKorisnik { get; set; }
        public int IdUčenik { get; set; }

        public virtual Korisnik IdUčenikNavigation { get; set; }
        public virtual Korisnik ZabilježioKorisnikNavigation { get; set; }
    }
}