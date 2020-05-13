using System.Collections.Generic;

namespace GradebookBLL.DomainModels
{
    public partial class Uloga
    {
        public Uloga()
        {
            KorisnikUloga = new HashSet<KorisnikUloga>();
        }

        public int IdUloga { get; set; }
        public string NazivUloga { get; set; }

        public virtual ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}