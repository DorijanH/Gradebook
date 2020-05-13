using System.Collections.Generic;

namespace GradebookBLL.DomainModels
{
    public partial class Predmet
    {
        public Predmet()
        {
            NastavnikPredaje = new HashSet<NastavnikPredaje>();
            Provjera = new HashSet<Provjera>();
        }

        public int IdPredmet { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int GodinaRazreda { get; set; }

        public virtual GodinaRazreda GodinaRazredaNavigation { get; set; }
        public virtual ICollection<NastavnikPredaje> NastavnikPredaje { get; set; }
        public virtual ICollection<Provjera> Provjera { get; set; }
    }
}