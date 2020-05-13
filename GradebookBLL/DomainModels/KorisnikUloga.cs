namespace GradebookBLL.DomainModels
{
    public partial class KorisnikUloga
    {
        public int IdKorisnik { get; set; }
        public int IdUloga { get; set; }

        public virtual Korisnik IdKorisnikNavigation { get; set; }
        public virtual Uloga IdUlogaNavigation { get; set; }
    }
}