using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Password> Passwords { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> Phones { get; set; }
        //public ICollection<BlogEntry> BlogEntries { get; set; }
        //public ICollection<FishEvent> FishEvents { get; set; } 
    }
}
