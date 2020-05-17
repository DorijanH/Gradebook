using System.Collections.Generic;
using GradebookBLL.DomainModels;

namespace GradebookBLL.IRepositories
{
    public interface IRazredRepository
    {
        List<Razred> GetAllRazredi();
    }
}