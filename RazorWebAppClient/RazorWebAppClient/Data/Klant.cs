namespace RazorWebAppClient.Data
{
    public class Klant
    {
        public int KlantId { get; set; }
        public string KlantNaam { get; set; }
        public bool GevalideerdeKlant => (KlantId > -1);
        public int LocatieId { get; set; }

        public Klant()
        {
            KlantId = 1;
            KlantNaam = string.Empty;
        }

        public Klant(int id, string naam, int locatieId)
        {
            KlantId = id;
            KlantNaam = naam;
            LocatieId = locatieId;
        }
    }
}
