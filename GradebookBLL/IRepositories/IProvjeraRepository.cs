using System.Collections.Generic;
using GradebookBLL.DomainModels;

namespace GradebookBLL.IRepositories
{
    public interface IProvjeraRepository
    {
        List<Provjera> GetAllProvjere();
        Provjera GetProvjera(int provjeraId);
        List<Provjera> GetDanašnjeProvjere();

        void AddProvjera(Provjera newProvjera);
        void UpdateProvjera(Provjera provjera);

        void AddOcjena(Ocjena newOcjena);
        List<Ocjena> GetOcjeneForProvjera(int provjeraId);
        void UpdateOcjena(Ocjena ocjena);
    }
}