using System.Collections.Generic;
using System.Linq;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GradebookSqlServerDAL.Repositories
{
    public class PredmetRepository : IPredmetRepository
    {
        private readonly GradebookDbContext _context;

        public PredmetRepository(GradebookDbContext context)
        {
            _context = context;
        }

        public List<Predmet> GetAllPredmeti()
        {
            return _context.Predmet.ToList();
        }

        public List<Korisnik> GetAllUceniciPredmeta(int predmetId)
        {
            var godinaPredmeta = _context.Predmet.First(p => p.IdPredmet == predmetId).GodinaRazreda;

            var razrediGodine = _context.Razred.Where(r => r.GodinaRazreda == godinaPredmeta).Include(r => r.Korisnik).ToList();

            List<Korisnik> output = new List<Korisnik>();

            foreach(var razred in razrediGodine)
            {
                output.AddRange(razred.Korisnik.ToList());
            }

            return output;
        }
    }
}