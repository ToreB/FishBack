using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FishBack.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public virtual ICollection<BlogEntry> BlogEntries { get; set; }
    }
}
