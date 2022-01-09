using CapgeminiDDD.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infraestructure.Repository
{
    public interface IClientRepository
    {
       public Task<Client> InsertClientAsync(Client client);
        public Task<Client> UpdateClientAsync(Client client);

        public void DeleteClient(int id);
        public Task<Client> GetClientByIdAsync(int id);

        public Task<Client> AddAddress(Client client);
        public Client DeleteAddress(Client client);

    }
}
