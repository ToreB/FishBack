using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Guid ClientId { get; set; }
        public string SoftwareVersion { get; set; }
    }
}
