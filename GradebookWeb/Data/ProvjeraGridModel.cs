using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradebookWeb.Data
{
    public class ProvjeraGridModel
    {
        public int ProvjeraId { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public int PredmetId { get; set; }
        public string Predmet { get; set; }
        public string Opis { get; set; }
    }
}
