using System.Collections.Generic;
using System.Linq;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;

namespace GradebookSqlServerDAL.Repositories
{
    public class BiljeskaRepository : IBiljeskaRepository
    {
        private readonly GradebookDbContext _context;

        public BiljeskaRepository(GradebookDbContext context)
        {
            _context = context;
        }

        public List<Biljeska> GetAllBilješke()
        {
            return _context.Bilješka.ToList();
        }
    }
}