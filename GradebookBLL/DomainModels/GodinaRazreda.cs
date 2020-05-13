using System.Collections.Generic;

namespace GradebookBLL.DomainModels
{
    public partial class GodinaRazreda
    {
        public GodinaRazreda()
        {
            Predmet = new HashSet<Predmet>();
            Razred = new HashSet<Razred>();
        }

        public int IdGodRazreda { get; set; }
        public short? BrojGodine { get; set; }

        public virtual ICollection<Predmet> Predmet { get; set; }
        public virtual ICollection<Razred> Razred { get; set; }
    }
}