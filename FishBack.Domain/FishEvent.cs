using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class FishEvent
    {
        public int Id { get; set; }

        public User User { get; set; }
        public Location Location { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Image> Images { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
