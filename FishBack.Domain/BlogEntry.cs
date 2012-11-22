using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class BlogEntry
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            BlogEntry b = (BlogEntry) obj;

            return Id == b.Id;
        }
    }
}
