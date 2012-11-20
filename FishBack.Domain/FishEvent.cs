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

        public override string ToString()
        {
            return String.Format("Id: {0} - Title: {1} - Comment: {2} - Location: {3} - DateTime:{4} - UserId: {5} - Images {6}", 
                Id, Title ?? "null", Comment ?? "null", Location == null ? "null" : Location.ToString(), DateTime, User == null ? "null" : User.Id.ToString(), Images == null ? "null" : Images.ToString());
        }
    }
}
