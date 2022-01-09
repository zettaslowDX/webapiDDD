using CapgeminiDDD.Common.Model;
using CapgeminiDDD.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CapgeminiDDD.Web.Api.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientController> _logger;
        public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<Client> Get(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        [HttpPost]
        public async Task<Client> Set(Client client)
        {
            return await _clientRepository.InsertClientAsync(client);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<Client> UpdateStudentAsync(Client client)
        {
            return await _clientRepository.UpdateClientAsync(client);
        }
    }
}
   
