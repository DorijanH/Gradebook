using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GradebookBLL.DomainModels;
using Syncfusion.Blazor.Grids.Internal;

namespace GradebookWeb.Data
{
    public class KorisnikGridModel
    {
        public int? IdKorisnik { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }

        public string PunoIme { get; set; }
        [Required]
        public string Spol { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdresa { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        public int? IdRazred { get; set; }
        public string Razred { get; set; }
        [Required]
        public int? UlogaId { get; set; }
        public string Uloga { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [DataType(DataType.Password)]
        [Compare("Lozinka", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string PotvrdaLozinke { get; set; }



        public static List<KorisnikGridModel> ToGridModel(List<Korisnik> korisnici, List<KorisnikUloga> uloge, List<Razred> razredi)
        {
            List<KorisnikGridModel> output = new List<KorisnikGridModel>();

            foreach (var korisnik in korisnici)
            {
                var korisnikovRazred = korisnik.IdRazred.HasValue
                    ? razredi.First(r => r.IdRazred == korisnik.IdRazred.Value)
                    : null;

                var korisnikoveUloge = uloge.Where(k => k.IdKorisnik == korisnik.IdKorisnik).Select(k => k.IdUloga).ToList();

                string korisnikovaUloga = "";

                if (korisnikoveUloge.Contains((int) Uloge.Admin))
                {
                    korisnikovaUloga = "Admin";
                }
                else if (korisnikoveUloge.Contains((int) Uloge.Razrednik))
                {
                    korisnikovaUloga = "Razrednik";
                }
                else if (korisnikoveUloge.Contains((int) Uloge.Nastavnik))
                {
                    korisnikovaUloga = "Nastavnik";
                }
                else
                {
                    korisnikovaUloga = "Učenik";
                }

                output.Add(new KorisnikGridModel
                {
                    IdKorisnik = korisnik.IdKorisnik,
                    Ime = korisnik.Ime,
                    Spol = korisnik.Spol,
                    PunoIme = $"{korisnik.Ime} {korisnik.Prezime}",
                    Prezime = korisnik.Prezime,
                    Dob = korisnik.DatumRođenja,
                    EmailAdresa = korisnik.EmailAdresa,
                    IdRazred = korisnik.IdRazred,
                    Razred = korisnik.IdRazred.HasValue ? $"{korisnikovRazred.GodinaRazreda}.{korisnikovRazred.KraticaOdjel}" : "-",
                    Uloga = korisnikovaUloga
                });
            }

            return output;
        }

        public static List<KorisnikGridModel> ToGridModel(List<Korisnik> korisnici)
        {
            return korisnici.Select(k => new KorisnikGridModel
            {
                IdKorisnik = k.IdKorisnik,
                Ime = k.Ime,
                Prezime = k.Prezime,
                PunoIme = $"{k.Ime} {k.Prezime}"
            }).ToList();
        }
    }
}