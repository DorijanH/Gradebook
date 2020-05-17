using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GradebookBLL.DomainModels
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            BilješkaIdUčenikNavigation = new HashSet<Biljeska>();
            BilješkaZabilježioKorisnikNavigation = new HashSet<Biljeska>();
            KorisnikUloga = new HashSet<KorisnikUloga>();
            NastavnikPredaje = new HashSet<NastavnikPredaje>();
            Ocjena = new HashSet<Ocjena>();
            Razred = new HashSet<Razred>();
        }

        public int IdKorisnik { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string PunoIme => $"{Ime} {Prezime}";
        [Required]
        public string Spol { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAdresa { get; set; }
        [Required]
        public DateTime DatumRođenja { get; set; }
        public int? IdRazred { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        public virtual Razred IdRazredNavigation { get; set; }
        public virtual ICollection<Biljeska> BilješkaIdUčenikNavigation { get; set; }
        public virtual ICollection<Biljeska> BilješkaZabilježioKorisnikNavigation { get; set; }
        public virtual ICollection<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual ICollection<NastavnikPredaje> NastavnikPredaje { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Razred> Razred { get; set; }
    }
}