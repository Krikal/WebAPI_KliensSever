using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi_common.Models;

namespace WebAPI_server.Repositories
{
    public class ClientRepository
    {
        public const string filename = "Client.json";

        public static IEnumerable<Client> GetClients()
        {
            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var clients = JsonSerializer.Deserialize<IEnumerable<Client>>(rawData);
                return clients;
            }
            return new List<Client>();
        }

        public static void StoreClients(IEnumerable<Client> clients)
        {
            var rawData = JsonSerializer.Serialize(clients);
            File.WriteAllText(filename, rawData);
        }
    }
}
