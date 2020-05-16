using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradebookBLL.DomainModels
{
    public partial class Provjera
    {
        public Provjera()
        {
            Ocjena = new HashSet<Ocjena>();
        }

        public int IdProvjera { get; set; }

        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }

        [Required]
        public DateTime? Datum { get; set; }

        [Required]
        public int IdPredmet { get; set; }

        public virtual Predmet IdPredmetNavigation { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
    }
}