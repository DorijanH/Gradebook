using System.Linq;
using GradebookBLL.DomainModels;
using GradebookBLL.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace GradebookSqlServerDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GradebookDbContext _context;

        public UserRepository(GradebookDbContext context)
        {
            _context = context;
        }

        public bool IsThereAdmin()
        {
            return _context.KorisnikUloga.Any(ku => ku.IdUloga == (int)Uloge.Admin);
        }
    }
}