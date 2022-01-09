using CapgeminiDDD.Common.Model;
using CapgeminiEF.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infraestructure.Repository
{
    public class ClientRepository : IClientRepository


    {
        public readonly CapgeminiContext _context;

        public void DeleteClient(int id)
        {
            var client = _context.Client.FirstOrDefault(d => d.Id == id);
            _context.Client.Remove(client);
            _context.SaveChanges();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context
                            .Client
                            .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Client> InsertClientAsync(Client client)
        {
            using (CapgeminiContext context = new CapgeminiContext())
            {

                _context.Add(client);
                await _context.SaveChangesAsync();
                return client;
            }
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var dbClient = await _context.Client
                            .FirstOrDefaultAsync(d => d.Id == client.Id);

            dbClient.Name = client.Name;
            dbClient.Surname = client.Surname;
            dbClient.addresses = client.addresses;

            await _context.SaveChangesAsync();

            return dbClient;
        }

       public Task<Client> AddAddress(Client client)
        {
            throw new NotImplementedException();
        }
       public Client DeleteAddress(Client client)
        {
            throw new NotImplementedException();
        }

       
    }
}
