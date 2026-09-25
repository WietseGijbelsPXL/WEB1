namespace RazorWebAppClient.Data
{
    public class Databank
    {
        public static List<Klant> Klanten { get; set; }
        public static void StartDataBank()
        {
            Klanten = new List<Klant>();
            Klanten.Add(new Klant(1, "Klant A"));
            Klanten.Add(new Klant(2, "Klant B"));
        }
        public static void AddKlant(string naam)
        {
            int id = Klanten.Max(k => k.KlantId) + 1;
            Klanten.Add(new Klant(id, naam));
        }
    }
}
