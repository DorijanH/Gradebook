using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;
using GradebookShared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GradebookSqlServerDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GradebookDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(GradebookDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool IsThereAdmin()
        {
            return _context.KorisnikUloga.Any(ku => ku.IdUloga == (int)Uloge.Admin);
        }

        public async Task<bool> CreateKorisnik(RegisterParameters registerParameters, Uloge uloga, int razredId = -1)
        {
            var user = new IdentityUser { UserName = registerParameters.Email, Email = registerParameters.Email };
            var result = await _userManager.CreateAsync(user, registerParameters.Password);

            //Add korisnik to the database
            _context.Add(new Korisnik
            {
                Ime = registerParameters.Ime,
                Prezime = registerParameters.Prezime,
                Spol = registerParameters.Spol,
                EmailAdresa = registerParameters.Email,
                DatumRođenja = registerParameters.DoB,
                User = user,
                IdRazred = razredId != -1 ? razredId : (int?)null
            });

            var userCreated = await _context.SaveChangesAsync(); //should be 1?

            //Get the createdUser id
            var newUserId = _context.Korisnik.First(k => k.EmailAdresa == registerParameters.Email).IdKorisnik;

            //Create KorisnikUloga with the User and Uloga pair
            var korisnikUloga = new KorisnikUloga {IdKorisnik = newUserId, IdUloga = (int) uloga};
            _context.Add(korisnikUloga);

            var ulogaCreated = await _context.SaveChangesAsync(); // should be 1?

            //Add the respected claims to the users for pages authentication and authorization
            var ulogaString = Enum.GetName(typeof(Uloge), uloga);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, ulogaString));

            if (userCreated == 1 && ulogaCreated == 1)
            {
                return true;
            }

            return false;

        }

        public List<Korisnik> GetAllKorisnici()
        {
            return _context.Korisnik.ToList();
        }

        public Korisnik GetKorisnikByEmail(string email)
        {
            return _context.Korisnik.Where(k => k.EmailAdresa == email)
                .Include(k => k.Ocjena)
                .ThenInclude(k => k.IdProvjeraNavigation)
                .Include(k => k.BilješkaIdUčenikNavigation)
                .ThenInclude(k => k.ZabilježioKorisnikNavigation)
                .First();
        }

        public void DeleteKorisnik(Korisnik korisnik)
        {
            _context.Remove(korisnik);
            _context.SaveChanges();

            _userManager.DeleteAsync(korisnik.User);
        }

        public void UpdateRazredKorisniku(int korisnikId, int razredId)
        {
            var korisnik = _context.Korisnik.First(k => k.IdKorisnik == korisnikId);

            korisnik.IdRazred = razredId;

            _context.Update(korisnik);
            _context.SaveChanges();
        }

        public int GetNumberOfTeachers()
        {
            return _context.KorisnikUloga.Count(ku =>
                (ku.IdUloga == (int) Uloge.Nastavnik || ku.IdUloga == (int) Uloge.Razrednik));
        }

        public int GetNumberOfStudents()
        {
            return _context.KorisnikUloga.Count(ku => ku.IdUloga == (int) Uloge.Učenik);
        }

        public int GetNumberOfClassrooms()
        {
            return _context.Razred.Count();
        }

        public List<KorisnikUloga> GetAllUloge()
        {
            return _context.KorisnikUloga.ToList();
        }
    }
}