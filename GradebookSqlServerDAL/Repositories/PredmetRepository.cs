using System.Collections.Generic;
using System.Linq;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;

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
    }
}