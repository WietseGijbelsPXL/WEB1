namespace RazorWebAppClient.Data
{
    public class Databank
    {
        public static List<Klant> Klanten { get; set; }
        public static List<Locatie> Locaties { get; set; }
        public static void StartDataBank()
        {
            Klanten = new List<Klant>();
            Klanten.Add(new Klant(1, "Klant A",1));
            Klanten.Add(new Klant(2, "Klant B",2));
            Locaties = new List<Locatie>();
            Locaties.Add(new Locatie(1, "3500", "Hasselt"));
            Locaties.Add(new Locatie(2, "3600", "Genk"));
        }
        public static void AddKlant(string naam, int locatieId)
        {
            int id = Klanten.Max(k => k.KlantId) + 1;
            Klanten.Add(new Klant(id, naam, locatieId));
        }

        public static void AddLocatie(string postcode, string gemeente)
        {
            int id = Locaties.Max(l => l.LocatieID) + 1;
            Locaties.Add(new Locatie(id, postcode, gemeente));
        }
    }
}
