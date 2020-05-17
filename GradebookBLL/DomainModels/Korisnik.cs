using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GradebookBLL.DomainModels
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            BilješkaIdUčenikNavigation = new HashSet<Bilješka>();
            BilješkaZabilježioKorisnikNavigation = new HashSet<Bilješka>();
            KorisnikUloga = new HashSet<KorisnikUloga>();
            NastavnikPredaje = new HashSet<NastavnikPredaje>();
            Ocjena = new HashSet<Ocjena>();
            Razred = new HashSet<Razred>();
        }

        public int IdKorisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string PunoIme => $"{Ime} {Prezime}";

        public string Spol { get; set; }
        public string EmailAdresa { get; set; }
        public DateTime DatumRođenja { get; set; }
        public int? IdRazred { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        public virtual Razred IdRazredNavigation { get; set; }
        public virtual ICollection<Bilješka> BilješkaIdUčenikNavigation { get; set; }
        public virtual ICollection<Bilješka> BilješkaZabilježioKorisnikNavigation { get; set; }
        public virtual ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual ICollection<NastavnikPredaje> NastavnikPredaje { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Razred> Razred { get; set; }
    }
}