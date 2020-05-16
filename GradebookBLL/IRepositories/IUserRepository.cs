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

        Task<bool> CreateKorisnik(RegisterParameters registerParameters, Uloge uloga);
        Korisnik GetKorisnikByEmail(string email);

        int GetNumberOfTeachers();
        int GetNumberOfStudents();
        int GetNumberOfClassrooms();



    }
}