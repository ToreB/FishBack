using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishBack.Domain;

namespace FishBack.DataAccess
{
    public class FishDbContext : DbContext
    {
        public FishDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FishEvent> FishEvents { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
