using WebAppMVCClientLocation.Models;

namespace WebAppMVCClientLocation.Data
{
    public static class Database
    {
        public static List<Client> Clients { get; set; }
        public static List<Location> Locations { get; set; }
        public static void StartDatabase()
        {
            //2 records in both lists
            Clients = new List<Client>
            {
                new Client { ClientId = 1, LocationId = 1, ClientName = "Client A" },
                new Client { ClientId = 2, LocationId = 2, ClientName = "Client B" }
            };
            Locations = new List<Location>
            {
                new Location { LocationId = 1, Postcode = "3000", City = "Leuven" },
                new Location { LocationId = 2, Postcode = "3500", City = "Hasselt" }
            };
        }

        public static InsertResult AddClient(Client c)
        {
            return null;
        }

        public static InsertResult AddLocation(Location l)
        {
            return null;
        }
    }
}
