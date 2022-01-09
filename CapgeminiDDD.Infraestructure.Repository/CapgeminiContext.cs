using CapgeminiDDD.Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgeminiEF.Infrastructure.Repository
{
    public class CapgeminiContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(config.GetConnectionString("CapgeminiDbContext"));
            }
        }
    }
}
