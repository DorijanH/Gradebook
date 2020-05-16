using System;

namespace GradebookBLL.DomainModels
{
    public partial class Bilješka
    {
        public int IdBilješka { get; set; }
        public string Opis { get; set; }
        public DateTime? Datum { get; set; }
        public int ZabilježioKorisnik { get; set; }
        public int IdUčenik { get; set; }

        public virtual Korisnik IdUčenikNavigation { get; set; }
        public virtual Korisnik ZabilježioKorisnikNavigation { get; set; }

        public string TimeSince()
        {
            var currentDate = DateTime.Now;

            if (Math.Round((currentDate - Datum.Value).Days / (365.25 / 12)) > 0)
            {
                return "Prije " + Math.Round((currentDate - Datum.Value).Days / (365.25 / 12)) + " mjeseci";
            }
            else if (Math.Round((currentDate - Datum.Value).TotalDays) > 0)
            {
                return "Prije " + Math.Round((currentDate - Datum.Value).TotalDays) + " dana";
            }
            else if (Math.Round((currentDate - Datum.Value).TotalHours) > 0)
            {
                return "Prije " + Math.Round((currentDate - Datum.Value).TotalHours) + " sati";
            }
            else if (Math.Round((currentDate - Datum.Value).TotalMinutes) > 0)
            {
                return "Prije " + Math.Round((currentDate - Datum.Value).TotalMinutes) + " minuta";
            }
            else if (Math.Round((currentDate - Datum.Value).TotalSeconds) > 0)
            {
                return "Prije " + Math.Round((currentDate - Datum.Value).TotalSeconds) + " sekundi";
            }
            return "Prije " + Math.Round((currentDate - Datum.Value).TotalMilliseconds) + " milisekundi";
        }
    }
}