using WebAppMVCClientLocation.Data;
using WebAppMVCClientLocation.Models;

namespace WebAppMVCClientLocation.ViewModels
{
    public class ClientLocationViewModel
    {
        public string ClientName { get; set; }
        public string City { get; set; }
        public IEnumerable<ClientLocationViewModel> Overview()
        {
            List<Client> clients = Database.Clients;
            List<Location> locations = Database.Locations;
            List<ClientLocationViewModel> clientLocations = new List<ClientLocationViewModel>();
            foreach (Client client in clients)
            {
                Location location = locations.FirstOrDefault(l => l.LocationId == client.LocationId);
                clientLocations.Add(new ClientLocationViewModel
                {
                    ClientName = client.ClientName,
                    City = location?.City
                });
            }
            return clientLocations;
        }
    }
}
