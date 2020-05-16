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
                .Include(p => p.IdPredmetNavigation.NastavnikPredaje)
                .Include(p => p.IdPredmetNavigation.GodinaRazredaNavigation)
                .ToList();
        }

        public List<Provjera> GetDanašnjeProvjere()
        {
            return _context.Provjera.Where(p => p.Datum.Value.Date == DateTime.Now.Date).ToList();
        }
    }
}