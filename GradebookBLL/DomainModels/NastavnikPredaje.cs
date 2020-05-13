namespace GradebookBLL.DomainModels
{
    public partial class NastavnikPredaje
    {
        public int IdNastavnik { get; set; }
        public int IdPredmet { get; set; }
        public int IdKriterij { get; set; }

        public virtual KriterijOcjenjivanja IdKriterijNavigation { get; set; }
        public virtual Korisnik IdNastavnikNavigation { get; set; }
        public virtual Predmet IdPredmetNavigation { get; set; }
    }
}