using System.Collections.Generic;
using GradebookBLL.DomainModels;

namespace GradebookBLL.IRepositories
{
    public interface IPredmetRepository
    {
        List<Predmet> GetAllPredmeti();
    }
}