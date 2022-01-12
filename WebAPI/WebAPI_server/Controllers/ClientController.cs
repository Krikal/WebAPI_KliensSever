using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_common.Models;
using WebAPI_server.Repositories;

namespace WebAPI_server.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            //return Ok(new[] { new Client {ClientName = "Krikal Csaladi", CarPlate = "AAA-111",CarType = "Audi", IssueDeatils = "Crashed by a tank" } });
            var clients = ClientRepository.GetClients();
            return Ok(clients);

        }

        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var clients = ClientRepository.GetClients();

            var client = clients.FirstOrDefault(x => x.Id == id);
            if (client != null)
            {
                return Ok(client);
            }

            return NotFound();
        }
        [HttpPost]
        public ActionResult Post([FromBody]Client client)
        {
            var clients = ClientRepository.GetClients().ToList();

            client.Id = GetNewId(clients);
            clients.Add(client);

            ClientRepository.StorePeople(clients);
            return Ok();
        }

        private long GetNewId(IEnumerable<Client> clients)
        {
            long newId = 0;

            foreach (var client in clients)
            {
                if (newId < client.Id)
                {
                    newId = client.Id;
                }

            }
            return newId + 1;
        }

        [HttpPut]
        public ActionResult Put([FromBody] Client client)
        {
            var clients = ClientRepository.GetClients().ToList();

            var clientToUpdate = clients.FirstOrDefault(x => x.Id == client.Id);
            if (clientToUpdate != null)
            {
                clientToUpdate.ClientName = client.ClientName;
                clientToUpdate.CarPlate = client.CarPlate;
                clientToUpdate.CarType = client.CarType;
                clientToUpdate.IssueDeatils = client.IssueDeatils;
                clientToUpdate.OrderDate = client.OrderDate;
                clientToUpdate.OrderStatus = client.OrderStatus;

                ClientRepository.StorePeople(clients);
                return Ok();

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var clients = ClientRepository.GetClients().ToList();

            var clientToDelete = clients.FirstOrDefault(x => x.Id == id);
            if (clientToDelete != null)
            {
                clients.Remove(clientToDelete);

                ClientRepository.StorePeople(clients);
                return Ok();
            }
            return NotFound();

        }
    }
}
