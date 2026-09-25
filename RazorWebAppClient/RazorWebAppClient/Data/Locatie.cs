namespace RazorWebAppClient.Data
{
    public class Locatie
    {
        public int LocatieID { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }

        public Locatie(int locatieID, string postcode, string gemeente)
        {
            LocatieID = locatieID;
            Postcode = postcode;
            Gemeente = gemeente;
        }
    }
}
