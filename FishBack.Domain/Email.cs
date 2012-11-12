using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Email
    {
        public int Id { get; set; }

        //public User User { get; set; }

        public string Address { get; set; }
        public int Priority { get; set; }
        public DateTime Date { get; set; }
    }
}
