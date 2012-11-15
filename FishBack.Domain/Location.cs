using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Location
    {
        public int Id { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal MAMSL { get; set; }
    }
}
