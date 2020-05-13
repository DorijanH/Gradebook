using System;
using System.Collections.Generic;

namespace GradebookBLL.DomainModels
{
    public partial class Provjera
    {
        public Provjera()
        {
            Ocjena = new HashSet<Ocjena>();
        }

        public int IdProvjera { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime? Datum { get; set; }
        public int IdPredmet { get; set; }

        public virtual Predmet IdPredmetNavigation { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
    }
}