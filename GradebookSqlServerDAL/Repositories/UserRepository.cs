using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;
using GradebookShared;
using Microsoft.AspNetCore.Identity;

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

        public async Task<bool> CreateKorisnik(RegisterParameters registerParameters, Uloge uloga)
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
                User = user
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

        public Korisnik GetKorisnikByEmail(string email)
        {
            return _context.Korisnik.First(k => k.EmailAdresa == email);
        }
    }
}