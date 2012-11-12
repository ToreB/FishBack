using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Session
    {
        public int  Id { get; set; }
        public Guid Token { get; set; }
        public DateTime Begin { get; set; }
        public DateTime Expires { get; set; }
    }
}
