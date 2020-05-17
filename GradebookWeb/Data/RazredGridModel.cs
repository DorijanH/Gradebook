using System.Collections.Generic;
using System.Linq;
using GradebookBLL.DomainModels;

namespace GradebookWeb.Data
{
    public class RazredGridModel
    {
        public string Oznaka { get; set; }
        public int? IdRazred { get; set; }

        public static List<RazredGridModel> ToGridModel(List<Razred> razredi)
        {
            return razredi.Select(r => new RazredGridModel
            {
                IdRazred = r.IdRazred,
                Oznaka = $"{r.GodinaRazreda}.{r.KraticaOdjel}"
            }).ToList();
        }
    }
}