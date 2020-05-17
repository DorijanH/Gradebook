using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradebookBLL.DomainModels;
using GradebookShared;
using Microsoft.AspNetCore.Identity;

namespace GradebookBLL.IRepositories
{
    public interface IUserRepository
    {
        bool IsThereAdmin();

        Task<bool> CreateKorisnik(RegisterParameters registerParameters, Uloge uloga, int idRazred = -1);
        List<Korisnik> GetAllKorisnici();
        Korisnik GetKorisnikByEmail(string email);
        void DeleteKorisnik(Korisnik korisnik);

        int GetNumberOfTeachers();
        int GetNumberOfStudents();
        int GetNumberOfClassrooms();

        List<KorisnikUloga> GetAllUloge();

    }
}