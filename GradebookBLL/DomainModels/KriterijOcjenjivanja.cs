using System.Collections.Generic;

namespace GradebookBLL.DomainModels
{
    public partial class KriterijOcjenjivanja
    {
        public KriterijOcjenjivanja()
        {
            NastavnikPredaje = new HashSet<NastavnikPredaje>();
        }

        public int IdKriterij { get; set; }
        public string Kriterij1 { get; set; }
        public string Kriterij2 { get; set; }
        public string Kriterij3 { get; set; }
        public string Kriterij4 { get; set; }

        public virtual ICollection<NastavnikPredaje> NastavnikPredaje { get; set; }
    }
}