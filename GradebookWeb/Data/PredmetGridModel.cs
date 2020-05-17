using GradebookBLL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradebookWeb.Data
{
    public class PredmetGridModel
    {
        public string Naziv { get; set; }
        public int? IdPredmet { get; set; }

        public static List<PredmetGridModel> ToGridModel(List<Predmet> predmeti)
        {
            return predmeti.Select(p => new PredmetGridModel
            {
                IdPredmet = p.IdPredmet,
                Naziv = p.Naziv
            }).ToList();
        }
    }
}
