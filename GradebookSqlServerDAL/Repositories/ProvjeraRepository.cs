using System;
using System.Collections.Generic;
using System.Linq;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GradebookSqlServerDAL.Repositories
{
    public class ProvjeraRepository : IProvjeraRepository
    {
        private readonly GradebookDbContext _context;

        public ProvjeraRepository(GradebookDbContext context)
        {
            _context = context;
        }

        public List<Provjera> GetAllProvjere()
        {
            return _context.Provjera
                .Include(p => p.IdPredmetNavigation)
                .Include(p => p.Ocjena)
                .ThenInclude(p => p.IdUčenikNavigation)
                .Include(p => p.IdPredmetNavigation.NastavnikPredaje)
                .Include(p => p.IdPredmetNavigation.GodinaRazredaNavigation)
                .ToList();
        }

        public List<Provjera> GetDanašnjeProvjere()
        {
            return _context.Provjera.Where(p => p.Datum.Value.Date == DateTime.Now.Date).ToList();
        }

        public void AddProvjera(Provjera newProvjera)
        {
            _context.Add(newProvjera);
            _context.SaveChanges();
        }

        public void UpdateProvjera(Provjera provjera)
        {
            _context.Update(provjera);
            _context.SaveChanges();
        }

        public void AddOcjena(Ocjena newOcjena)
        {
            _context.Add(newOcjena);
            _context.SaveChanges();
        }

        public List<Ocjena> GetOcjeneForProvjera(int provjeraId)
        {
            return _context.Ocjena.Where(o => o.IdProvjera == provjeraId).Include(o => o.IdUčenikNavigation).ToList();
        }

        public void UpdateOcjena(Ocjena ocjena)
        {
            _context.Update(ocjena);
            _context.SaveChanges();
        }

        public Provjera GetProvjera(int provjeraId)
        {
            return _context.Provjera.First(p => p.IdProvjera == provjeraId);
        }
    }
}