using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Phone
    {
        public int Id { get; set; }

        //public User User { get; set; }

        public string Number { get; set; }
        public string CountryCode { get; set; }
        public DateTime Date { get; set; }
    }
}
