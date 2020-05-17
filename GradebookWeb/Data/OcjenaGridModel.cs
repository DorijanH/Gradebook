using GradebookBLL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace GradebookWeb.Data
{
    public class OcjenaGridModel
    {
        public int OcjenaId { get; set; }
        public string UcenikIme { get; set; }
        public int OstvareniBodovi { get; set; }
        public string Bilješka { get; set; }
        public int Ocjena1 { get; set; }

        public static List<OcjenaGridModel> ToGridModel(List<Ocjena> ocjene)
        {
            return ocjene.Select(o => new OcjenaGridModel
            {
                UcenikIme = o.IdUčenikNavigation.Ime + o.IdUčenikNavigation.Prezime,
                Bilješka = o.Bilješka,
                Ocjena1 = o.Ocjena1,
                OstvareniBodovi = o.OstvareniBodovi ?? 0
            }).ToList();
        }
    }
}