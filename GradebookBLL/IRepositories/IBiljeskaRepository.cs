using System.Collections.Generic;
using GradebookBLL.DomainModels;

namespace GradebookBLL.IRepositories
{
    public interface IBiljeskaRepository
    {
        List<Bilješka> GetAllBilješke();
    }
}