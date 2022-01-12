using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi_common.Models;

namespace WebApi_common.DataProviders
{
    public class ClientDataProvider
    {
        private const string _url = "http://localhost:5000/api/client";

        public static IEnumerable<Client> GetClients()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(rawData);
                    var sortedClients = from c in clients orderby c.OrderDate select c;

                    return sortedClients;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateClient(Client client)
        {
            using (var HttpClient = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(client);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = HttpClient.PostAsync(_url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteClient(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateClient(Client client)
        {
            using (var HttpClient = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(client);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = HttpClient.PutAsync(_url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }

}
