using System.Collections.Generic;
using GradebookBLL.DomainModels;

namespace GradebookBLL.IRepositories
{
    public interface IProvjeraRepository
    {
        List<Provjera> GetAllProvjere();
        List<Provjera> GetDanašnjeProvjere();


    }
}