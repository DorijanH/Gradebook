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
        void DeleteProvjeraById(int provjeraId);

        void AddOcjena(Ocjena newOcjena);
        Ocjena GetOcjena(int ocjenaId);
        List<Ocjena> GetOcjeneForProvjera(int provjeraId);
        void UpdateOcjena(Ocjena ocjena);
        void DeleteOcjenaById(int ocjenaId);
    }
}