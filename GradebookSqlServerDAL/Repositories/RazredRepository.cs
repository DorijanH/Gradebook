using System.Collections.Generic;
using System.Linq;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;

namespace GradebookSqlServerDAL.Repositories
{
    public class RazredRepository : IRazredRepository
    {
        private readonly GradebookDbContext _context;

        public RazredRepository(GradebookDbContext context)
        {
            _context = context;
        }

        public List<Razred> GetAllRazredi()
        {
            return _context.Razred.ToList();
        }
    }
}