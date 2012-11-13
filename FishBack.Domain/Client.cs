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

        public override string ToString()
        {
            return String.Format("Id: {0} - Type: {1} - ClientId: {2} - SoftwareVersion: {3}", Id, Type, ClientId, SoftwareVersion);
        }
    }

    
}
